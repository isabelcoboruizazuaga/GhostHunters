using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{

    void Start()
    {  
    }

    public void Play()
    {
        SceneManager.LoadScene("gameScene");
    }

    public void CloseGame()
    {
        Application.Quit();
    }

}
