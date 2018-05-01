using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class DropshipAI : MonoBehaviour {

    public GameObject[] enemyTypes;
    public Transform[] spawnPoints;
    private Transform dropArea;
    public float areaRangeX = 5;
    public float areaRangeY = 3;
    public float areaRangeZ = 5;

    public float shipSpeed = 5;

    public Vector3 target;
    public float spawnTime = 1;
    public int enemiesCount;
    private int enemiesCurrent;

    private GameObject enemySpawned;

    // Use this for initialization
    void Start () {
        dropArea = GameManager.GM.dropZones[Random.Range(0, GameManager.GM.dropZones.Length)];
        target = new Vector3(Random.Range(dropArea.position.x - areaRangeX, dropArea.position.x + areaRangeX), Random.Range(dropArea.position.y - areaRangeY, dropArea.position.y + areaRangeY), Random.Range(dropArea.position.z - areaRangeZ, dropArea.position.z + areaRangeZ));
	}
	
	// Update is called once per frame
	void Update () {

        if (!IsAboveNavMesh())
        {
            target = new Vector3(Random.Range(dropArea.position.x - areaRangeX, dropArea.position.x + areaRangeX), Random.Range(dropArea.position.y - areaRangeY, dropArea.position.y + areaRangeY), Random.Range(dropArea.position.z - areaRangeZ, dropArea.position.z + areaRangeZ));
            return;
        }

        //check if needs to move
        if (target != Vector3.zero)
        {
            //move to target
            transform.LookAt(target);
            float step = shipSpeed * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, target, step);

            //check if has reached target
            if (transform.position == target)
            {
                //check of target is a valid point to spawn
                if (IsAboveNavMesh())
                {
                    //start spawning and stop moving
                    StartCoroutine("SpawnEnemy");
                    target = Vector3.zero;
                }
                //else pick a new move target
                else
                {
                    target = new Vector3(Random.Range(dropArea.position.x - areaRangeX, dropArea.position.x + areaRangeX), Random.Range(dropArea.position.y - areaRangeY, dropArea.position.y + areaRangeY), Random.Range(dropArea.position.z - areaRangeZ, dropArea.position.z + areaRangeZ));
                }
            }      
        }
        //move away once finished spawning
        if (enemiesCurrent >= enemiesCount)
        {
            float step = shipSpeed * Time.deltaTime;
            transform.Translate(Vector3.forward * step);
            Destroy(gameObject, 30);
        }
    }

    //spawn enemies at interval
    IEnumerator SpawnEnemy()
    {
        enemySpawned = Instantiate(enemyTypes[Random.Range(0, enemyTypes.Length)], spawnPoints[Random.Range(0, spawnPoints.Length)].position, Quaternion.identity);
        GameManager.GM.enemies.Add(enemySpawned);
        enemiesCurrent++;
        if (enemiesCurrent < enemiesCount)
        {
            yield return new WaitForSeconds(spawnTime);
            StartCoroutine("SpawnEnemy");
        }
        yield break;
    }

    //check of target is above navmesh
    public bool IsAboveNavMesh()
    {
        RaycastHit hit;
        NavMeshHit hit1;

        if (Physics.Raycast(target, Vector3.down, out hit))
        {
            //print(hit.point);
            if (NavMesh.SamplePosition(hit.point, out hit1, 1.0f, NavMesh.AllAreas))
            {
                //print(hit1.position);
                return true;
            }
            return false;
        }

        return false;
    }


}
