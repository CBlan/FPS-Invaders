using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseManager : MonoBehaviour
{
    public KeyCode pauseButton;
    public GameObject pausePanel;
    public bool paused = false;
    public GameObject playerTut;
    public GameObject pauseScreen;

    public static PauseManager instance;

    private void Awake()
    {
        instance = this;
        Cursor.visible = paused;
        Cursor.lockState = CursorLockMode.Locked;
    }

    public void Update()
    {
        if (Input.GetKeyDown(pauseButton))
        {
            PauseGame();
            playerTut.SetActive(false);
            pauseScreen.SetActive(true);
        }
    }

    public void PauseGame()
    {
        paused = !paused;
        pausePanel.SetActive(paused);

        Cursor.visible = paused;

        if (paused)
        {
            Cursor.lockState = CursorLockMode.None;
            Time.timeScale = 0f;
        }
        else
        {

            Cursor.lockState = CursorLockMode.Locked;
            Time.timeScale = 1f;
        }
    }

}
