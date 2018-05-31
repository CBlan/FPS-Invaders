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
    private Scene thisScene;
    // Use this for initialization
    void Start () {
        GM = this;
        StartCoroutine("SpawnDropShips");
        thisScene = SceneManager.GetActiveScene();
        PauseManager.instance.PauseGame();
        //CameraFade.StartAlphaFade(Color.black, true, 5f);
    }


    // Update is called once per frame
    void Update () {

        for (var i = portals.Count - 1; i > -1; i--)
        {
            if (portals[i] == null)
            {
                portals.RemoveAt(i);
                Camera.main.GetComponent<Motion_Shake>().Shake(0.5f, 1f);
            }
        }

        for (var i = enemies.Count - 1; i > -1; i--)
        {
            if (enemies[i] == null)
            {
                enemies.RemoveAt(i);
                Camera.main.GetComponent<Motion_Shake>().Shake(0.1f, 0.2f);
            }
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
        yield return new WaitForSeconds(2.3f);
        CameraFade.StartAlphaFade(Color.black, false, 5f);
        UnityEngine.Analytics.AnalyticsEvent.GameOver();
        UnityEngine.Analytics.AnalyticsEvent.LevelComplete(thisScene.name, thisScene.buildIndex);
        yield return new WaitForSeconds(2.3f);
        SceneManager.LoadScene("Win");
        yield break;
    }

    IEnumerator GameLost()
    {
        yield return new WaitForSeconds(2.3f);
        CameraFade.StartAlphaFade(Color.black, false, 5f);
        UnityEngine.Analytics.AnalyticsEvent.GameOver();
        UnityEngine.Analytics.AnalyticsEvent.LevelFail(thisScene.name, thisScene.buildIndex);
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
