using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenuController : MonoBehaviour
{
    public void Menu()
    {
        PauseGame.GoToMainMenu();
    }
    public void Resume()
    {
        PauseGame.UnPause();
    }

    public void Snsitivity()
    {

    }

    public void MoreSensitivity()
    {
        if(GameManager.sensitivity<200) GameManager.sensitivity += 20;
    }

    public void LessSensitivity()
    {
        if (GameManager.sensitivity > 0) GameManager.sensitivity -= 20;
    }
}
