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

    // Use this for initialization
    void Start () {
        agent = GetComponent<NavMeshAgent>();
        rB = GetComponent<Rigidbody>();
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

            if (Physics.Raycast(transform.position, Vector3.down, out hit))
            {
                if (transform.position.y - activationHeight <= hit.point.y)
                {
                    agent.enabled = true;
                }
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
            Instantiate(explosionEffect, transform.position, Quaternion.identity);
            collision.gameObject.GetComponent<Health>().hP -= enemyDamage;
            Destroy(gameObject);
        }
    }
}
