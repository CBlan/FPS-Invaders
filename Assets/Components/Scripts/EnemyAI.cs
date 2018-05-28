using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour {

    public GameObject target;
    private NavMeshAgent agent;
    private Rigidbody rB;
    public float activationHeight = 2;
    public float enemyDamage;
    public GameObject explosionEffect;
    public LayerMask mask;
    private bool hasCollided;
    public GameObject thrusters;
    public GameObject landingEffect;
    private GameObject landEffect;

    // Use this for initialization
    void Start () {
        agent = GetComponent<NavMeshAgent>();
        rB = GetComponent<Rigidbody>();
        Fabric.EventManager.Instance.PostEvent("Exploder/WarpIn", gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        if (target == null)
        {
            if (GameManager.GM.portals.Count > 0)
            {
                target = GameManager.GM.portals[Random.Range(0, GameManager.GM.portals.Count)];
            }
            else
            {
                target = this.gameObject;
            }
        }

        if (agent.enabled && target != null)
        {
            agent.SetDestination(target.transform.position);
        }

        if (!agent.enabled)
        {
            RaycastHit hit;
            Ray ray = new Ray(transform.position, Vector3.down);

            if (Physics.Raycast(ray, out hit, activationHeight, mask.value))
            {
                landEffect = Instantiate(landingEffect, hit.point, Quaternion.identity);
                Fabric.EventManager.Instance.PostEvent("Exploder/Activate", gameObject);
                Fabric.EventManager.Instance.PostEvent("Exploder/Movement", gameObject);
                //landEffect.transform.SetParent(this.gameObject.transform);
                agent.enabled = true;
                transform.GetChild(0).gameObject.GetComponent<Motion_Bobbing>().enabled = true;
                thrusters.SetActive(true);
                //rB.isKinematic = true;
                rB.drag = 1000;
            }
        }

    }

    private void OnCollisionEnter(Collision collision)
    {
        //if (!agent.enabled)
        //{
        //    agent.enabled = true;
        //}

        if (collision.gameObject.tag == "Portal")
        {
            if (!hasCollided)
            {
                hasCollided = true;
                Instantiate(explosionEffect, transform.position, Quaternion.identity);
                collision.gameObject.GetComponent<Health>().hP -= enemyDamage;
                Destroy(gameObject);
            }
        }
    }
}
