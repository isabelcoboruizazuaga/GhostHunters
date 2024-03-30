using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class CameraLook : MonoBehaviour
{
    //public float mouseSensitivity;
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
      
        float mouseX = Input.GetAxis("Mouse X") * GameManager.sensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * GameManager.sensitivity * Time.deltaTime;
        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -50f, 90f);


        transform.localRotation = Quaternion.Euler(xRotation, 0, 0);
        playerBody.Rotate(Vector3.up * mouseX);
    }
}
