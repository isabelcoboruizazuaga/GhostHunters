using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController characterController;
    public float speed;

    //Gravedad
    public float gravity = -9.8f;
    Vector3 velocity;

    //GroundCheck
    public Transform groundCheck;
    public float sphereRadius = 0.3f;
    public LayerMask groundMask;
    public bool isGrounded;

    //Salto
    public float jumpHeight = 300f;

    //Correr
    public bool isSprinting = false;
    public float sprintingSpeedMultiplier = 2f;
    public float sprintSpeed = 1;

    private StaminaBar staminaSlider;
    public float staminaAmount = 5;

    //Dinero
    public int money = 0;
    public TextMeshProUGUI coinText;

    // Start is called before the first frame update
    void Start()
    {
        staminaSlider = FindObjectOfType<StaminaBar>();
        addCoins(0);
    }

    // Update is called once per frame
    void Update()
    {
        //Movimiento
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");
        Vector3 move = transform.right * x + transform.forward * z;
        characterController.Move(move * speed * Time.deltaTime * sprintSpeed);

        //Gravedad
        velocity.y += gravity * Time.deltaTime;
        characterController.Move(velocity * Time.deltaTime);

        //Grounded check
        isGrounded = Physics.CheckSphere(groundCheck.position, sphereRadius, groundMask);
        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        //Salto
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2 * gravity * Time.deltaTime);
        }

        RunCheck();
    }

    public void addCoins( int coinsToAdd)
    {
        money += coinsToAdd;
        coinText.text = money.ToString()+"$";
    }

   private void RunCheck()
    {
        //Si corremos perdemos stamina, al soltar recuperamos
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            staminaSlider.UseStamina(staminaAmount);

            /*isSprinting = !isSprinting;
            if (isSprinting)
            {
                sprintSpeed = sprintingSpeedMultiplier;
                staminaSlider.UseStamina(staminaAmount);
            }
            else
            {
                sprintSpeed = 1;
                staminaSlider.UseStamina(0);
            }*/
        }
        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            staminaSlider.RecoverStamina();
        }
    }
}
