using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenuController : MonoBehaviour
{
    public TextMeshProUGUI sensitivityText;

    private void Start()
    {

        SetText();
    }

    public void Menu()
    {
        PauseGame.GoToMainMenu();
    }
    public void Resume()
    {
        PauseGame.UnPause();
    }

    public void MoreSensitivity()
    {
        if(GameManager.sensitivity<200) GameManager.sensitivity += 20;
        SetText();
    }

    public void LessSensitivity()
    {
        if (GameManager.sensitivity > 20) GameManager.sensitivity -= 20;
        SetText();
    }

    private void SetText()
    {
        sensitivityText.text = (GameManager.sensitivity/20).ToString();
    }
}
