using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    public static GameManager GM;
    //public List<GameObject> defensePoints;

    public List<GameObject> portals;
    public List<GameObject> enemies;

    public Transform[] dropZones;

    public Transform[] dropShipSpawns;
    public GameObject dropshipPrefab;
    public int dropShipsToSpawn;
    public float timeBetweenSpawns;
    private int dropshipsSpawned;
    private GameObject dropshipSpawned;
    public GameObject winPannel;
    public GameObject lossPannel;
    // Use this for initialization
    void Start () {
        GM = this;
        StartCoroutine("SpawnDropShips");
    }
	
	// Update is called once per frame
	void Update () {

        for (var i = portals.Count - 1; i > -1; i--)
        {
            if (portals[i] == null)
                portals.RemoveAt(i);
        }

        for (var i = enemies.Count - 1; i > -1; i--)
        {
            if (enemies[i] == null)
                enemies.RemoveAt(i);
        }

        if (dropshipsSpawned == dropShipsToSpawn && enemies.Count == 0 )
        {
            GameWon();
        }

        if (portals.Count == 0)
        {
            GameLost();
        }

    }

    void GameWon()
    {
        //print("Won Game");
        winPannel.SetActive(true);
    }

    void GameLost()
    {
        //print("Lost Game");
        lossPannel.SetActive(true);
    }

    IEnumerator SpawnDropShips()
    {
        yield return new WaitForSeconds(timeBetweenSpawns);
        dropshipSpawned = Instantiate(dropshipPrefab, dropShipSpawns[Random.Range(0, dropShipSpawns.Length)].position, Quaternion.identity);
        GameManager.GM.enemies.Add(dropshipSpawned);
        dropshipsSpawned++;
        if (dropshipsSpawned < dropShipsToSpawn)
        {
            //yield return new WaitForSeconds(timeBetweenSpawns);
            StartCoroutine("SpawnDropShips");
        }
        yield break;
    }
}
