using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeadMenuController : MonoBehaviour
{
    public TextMeshPro axeGhostTxt, witchGhostTxt, demonGhostTxt;
    public TextMeshProUGUI moneyTxt;
    // Start is called before the first frame update
    void Start()
    {   //Activate cursor
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

        //Show stats
        axeGhostTxt.text = "x" + GameManager.axeGhostsKilled.ToString();
        witchGhostTxt.text = "x" + GameManager.witchGhostsKilled.ToString();
        demonGhostTxt.text = "x" + GameManager.demonhGhostsKilled.ToString();
        moneyTxt.text = GameManager.money.ToString() + "$";
    }

    public void PlayAgain()
    {
        SceneManager.LoadScene("gameScene");
    }

    public void CloseGame()
    {
        Application.Quit();
    }

    // Update is called once per frame
    void Update()
    {

    }
}
