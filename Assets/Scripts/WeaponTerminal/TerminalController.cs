using System;
using UnityEngine;

public class TerminalController : MonoBehaviour
{
    private bool playerInRange = false;
    public Canvas shopTerminal;


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
        GameObject.Find("PlayerHUD").GetComponent<Canvas>().enabled = false; 

        //Activate cursor
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

        //Block player and camera movement
        GameObject.FindWithTag("Player").GetComponent<PlayerMovement>().enabled = false;
        GameObject.FindWithTag("MainCamera").GetComponent<CameraLook>().enabled = false;
        GameObject.FindWithTag("Weapon").GetComponent<GunController>().enabled = false;
        try
        {
            GameObject.FindWithTag("Weapon").GetComponent<MeshRenderer>().enabled = false;
        }
        catch (Exception ex)
        {
            GameObject.FindWithTag("Weapon").GetComponentInChildren<MeshRenderer>().enabled = false;
        }

        shopTerminal.GetComponent<TerminalUI>().Clear();
    }


    private void HidePanel()
    {
        //Hide shopping panel
        shopTerminal.GetComponent<Canvas>().enabled = false;
        GameObject.Find("PlayerHUD").GetComponent<Canvas>().enabled = true;

        //Deactivate cursor
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        //Unblock player and camera movement
        GameObject.FindWithTag("Player").GetComponent<PlayerMovement>().enabled = true;
        GameObject.FindWithTag("MainCamera").GetComponent<CameraLook>().enabled = true;
        GameObject.FindWithTag("Weapon").GetComponent<GunController>().enabled = true; 
        
        try
        {
            GameObject.FindWithTag("Weapon").GetComponent<MeshRenderer>().enabled = true;
        }
        catch (Exception ex)
        {
            GameObject.FindWithTag("Weapon").GetComponentInChildren<MeshRenderer>().enabled = true;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = true;
        }
    }
   
}
