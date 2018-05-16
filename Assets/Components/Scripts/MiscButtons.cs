using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MiscButtons : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
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

    public void LoadMain()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Main");
    }

    public void LoadStart()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Start");
    }
}
