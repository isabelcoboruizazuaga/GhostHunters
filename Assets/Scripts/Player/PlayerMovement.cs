using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController characterController;
    public float speed;

    //Gravity
    public float gravity = -9.8f;
    Vector3 velocity;

    //GroundCheck
    public Transform groundCheck;
    public float sphereRadius = 0.3f;
    public LayerMask groundMask;
    public bool isGrounded;

    //Jump
    public float jumpHeight = 300f;

    //Sprint
    public bool isSprinting = false;
    public float sprintingSpeedMultiplier = 1f;
    public float sprintSpeed = 1;

    private StaminaBar staminaSlider;
    private bool canSprint=false;
    public float staminaAmount = 5;

    //Money
    public int money = 0;
    public TextMeshProUGUI coinText;

    //Sound 
    public AudioSource audioJump;

    // Start is called before the first frame update
    void Start()
    {
        staminaSlider = FindObjectOfType<StaminaBar>();
        addCoins(0);
    }

    // Update is called once per frame
    void Update()
    {
        //Movement
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");
        
        if (x > 0.09 || z > 0.09) {canSprint = true; }
        else canSprint = false;

        Vector3 move = transform.right * x + transform.forward * z;
        characterController.Move(move * speed * Time.deltaTime * sprintingSpeedMultiplier);

        //Gravity
        velocity.y += gravity * Time.deltaTime;
        characterController.Move(velocity * Time.deltaTime);

        //Grounded check
        isGrounded = Physics.CheckSphere(groundCheck.position, sphereRadius, groundMask);
        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        //Input checks, should be stopped when game paused
        if (!GameManager.isPaused)
        {
            //Jump
            if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
            {
                audioJump.Play();
                velocity.y = Mathf.Sqrt(jumpHeight * -2 * gravity * Time.deltaTime);
            }

            RunCheck();
        }
        
    }

    public void addCoins( int coinsToAdd)
    {
        money += coinsToAdd;
        coinText.text = money.ToString()+"$";
    }

   private void RunCheck()
    {
        //Makes sure player is moving to sprint
        if(canSprint)
        {
            //Start using stamina when button pressed
            if (Input.GetKeyDown(KeyCode.LeftShift))
            {
                staminaSlider.UseStamina();
            }
        }
        //Start recovering stamina when key up
        if (Input.GetKeyUp(KeyCode.LeftShift) )
        {
            staminaSlider.RecoverStamina();
        }

    }
}
