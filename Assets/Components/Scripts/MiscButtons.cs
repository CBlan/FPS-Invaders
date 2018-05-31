using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MiscButtons : MonoBehaviour {

    private Scene thisScene;

    // Use this for initialization
    void Start () {
        thisScene = SceneManager.GetActiveScene();
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void QuitGame()
    {
        Application.Quit();
    }

    public void StartGame()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("LoadScene");
    }


    public void LoadStart()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Start");
        UnityEngine.Analytics.AnalyticsEvent.LevelQuit(thisScene.name, thisScene.buildIndex);
    }
}
