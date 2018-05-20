using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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
    private bool hasFin;
    // Use this for initialization
    void Start () {
        GM = this;
        StartCoroutine("SpawnDropShips");
        PauseManager.instance.PauseGame();
        //CameraFade.StartAlphaFade(Color.black, true, 5f);
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

        if (dropshipsSpawned == dropShipsToSpawn && enemies.Count == 0 && !hasFin)
        {
            StartCoroutine("GameWon");
            hasFin = true;
        }

        if (portals.Count == 0 && !hasFin)
        {
            StartCoroutine("GameLost");
            hasFin = true;
        }

    }

    IEnumerator GameWon()
    {
        CameraFade.StartAlphaFade(Color.black, false, 5f);
        yield return new WaitForSeconds(2.3f);
        SceneManager.LoadScene("Win");
        yield break;
    }

    IEnumerator GameLost()
    {
        CameraFade.StartAlphaFade(Color.black, false, 5f);
        yield return new WaitForSeconds(2.3f);
        SceneManager.LoadScene("Loss");
        yield break;
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
