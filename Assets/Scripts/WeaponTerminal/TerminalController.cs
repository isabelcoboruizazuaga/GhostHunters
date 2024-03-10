using UnityEngine;

public class TerminalController : MonoBehaviour
{
    private bool playerInRange = false;

    public Canvas shopTerminal;
    // Start is called before the first frame update
    void Start()
    {
        shopTerminal.GetComponent<Canvas>().enabled = false;        
    }

    // Update is called once per frame
    void Update()
    {
        if (playerInRange)
        {
            if (Input.GetKeyDown(KeyCode.F))
            {
                ShowPanel();
            }
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                HidePanel();
            }

        }
    }

    private void ShowPanel()
    {
        //Show shopping panel
        shopTerminal.GetComponent<Canvas>().enabled = true;

        //Activate cursor
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

        //Block player and camera movement
        GameObject.FindWithTag("Player").GetComponent<PlayerMovement>().enabled = false;
        GameObject.FindWithTag("MainCamera").GetComponent<CameraLook>().enabled = false;
        GameObject.FindWithTag("Weapon").GetComponent<GunController>().enabled = false;
        GameObject.FindWithTag("Weapon").GetComponent<MeshRenderer>().enabled = false;
    }


    private void HidePanel()
    {
        //Hide shopping panel
        shopTerminal.GetComponent<Canvas>().enabled = false;

        //Deactivate cursor
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        //Unblock player and camera movement
        GameObject.FindWithTag("Player").GetComponent<PlayerMovement>().enabled = true;
        GameObject.FindWithTag("MainCamera").GetComponent<CameraLook>().enabled = true;
        GameObject.FindWithTag("Weapon").GetComponent<GunController>().enabled = true;
        GameObject.FindWithTag("Weapon").GetComponent<MeshRenderer>().enabled = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = true;
        }
    }
   
}
