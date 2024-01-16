using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class CameraLook : MonoBehaviour
{
    public float mouseSensitivity = 500f;
    public Transform playerBody;

    private float xRotation = 0;
    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        transform.localRotation = Quaternion.Euler(7.95f, 0f, 0f);
    }

    // Update is called once per frame
    void Update()
    {
       /* if (GameManager.instance.muerto)
        {
            return;
        }*/
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;
        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -50f, 90f);


        transform.localRotation = Quaternion.Euler(xRotation, 0, 0);
        playerBody.Rotate(Vector3.up * mouseX);
        //playerBody.Rotate(Vector3.left * mouseY);
    }
}
