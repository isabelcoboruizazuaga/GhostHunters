using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseGame : MonoBehaviour
{
    private static Canvas pauseMenu;
    // Start is called before the first frame update
    void Start()
    {
        pauseMenu= GameObject.Find("PauseMenu").GetComponent<Canvas>();

    }

    public static void Pause()
    {
        pauseMenu.enabled = true;

        Time.timeScale = 0;
        AudioListener.pause = true;

        //Activate cursor
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

        GameManager.isPaused = true;

    }

    public static void UnPause()
    {
        pauseMenu.enabled = false;

        Time.timeScale = 1;
        AudioListener.pause = false;


        //Deactivate cursor
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        GameManager.isPaused= false;
    }

    public static void GoToMainMenu()
    {
        pauseMenu.enabled = false;

        Time.timeScale = 1;
        AudioListener.pause = false;

        GameManager.isPaused = false;


        SceneManager.LoadScene("HomeScene");
    }
}
