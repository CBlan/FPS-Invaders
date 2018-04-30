using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour {

    public GameObject target;
    private NavMeshAgent agent;
    private Rigidbody rB;

    // Use this for initialization
    void Start () {
        agent = GetComponent<NavMeshAgent>();
        rB = GetComponent<Rigidbody>();
    }
	
	// Update is called once per frame
	void Update () {
        if (target == null)
        {
            target = GameManager.GM.portals[Random.Range(0, GameManager.GM.portals.Count)];
        }

        if (agent.enabled)
        {
            agent.SetDestination(target.transform.position);
        }
	}

    private void OnCollisionEnter(Collision collision)
    {
        if (!agent.enabled)
        {
            agent.enabled = true;
        }

        if (collision.gameObject.tag == "Portal")
        {
            Destroy(gameObject);
        }
    }
}
