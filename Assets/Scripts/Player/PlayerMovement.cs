using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController characterController;
    public float speed;
    Vector3 move;


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


    //////////////////
    public float staminaAmount = 1f;
    private StaminaBar staminaSlider;


    private float maxStamina;
    private float regenerateAmount = .5f;
    private float staminaRegenerateTime = 0.1f;
    private float losingAmount = 1;
    private float losingStaminaTime = 0.1f;

    private float _currentSatamina;


    //Stamina Max Value getter
    public float MaxStamina => maxStamina;


    public UnityEvent<float> OnHealthChanged;
    public UnityEvent<float> OnStaminaChanged;

    public float currentStamina
    {
        get => currentStamina;
        private set
        {
            currentStamina = currentStamina; //Mathf.Clamp(value, 0, maxStamina); //REVISA ESTOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOO

            OnStaminaChanged.Invoke(currentStamina);
        }
    }
    //////////////////

    [SerializeField] private float _maxStamaina = 100f;
    [SerializeField] private float _staminaDrainPerSecond = 2f;
    [SerializeField] private float _secondsDelayBeforeStaminaRegen = 1f;
    [SerializeField] private float _staminaRegenPerSecond = 2f;
    [SerializeField] private float _playerSpeed = 1f;
    [SerializeField] private float _playerRunSpeed = 2f;
    [SerializeField] private float _jumpHeight = 1f;
    [SerializeField] private float _gravityValue = -9.81f;

    // Your runtime values
    private float _staminaRegenDelayTimer;
    private float _currentStamina;

    // You only need a single float for this
    private float _currentYVelocity;


    public float MaxSstamina => _maxStamaina;








    //Dinero
    public int money = 0;
    public TextMeshProUGUI coinText;



    
   
    private void Awake()
    {
        currentStamina = MaxStamina;
    }
    // Start is called before the first frame update
    void Start()
    {
        staminaSlider = FindObjectOfType<StaminaBar>();
        addCoins(0);
    }

    // Update is called once per frame
    void Update()
    {
        UpdateStamina();

        //Movimiento
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");
        move = transform.right * x + transform.forward * z;
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
        if (true) //sprinting) //Input.GetKeyDown(KeyCode.LeftShift)&& (Input.GetAxis("Horizontal") + Input.GetAxis("Vertical") != 0)
        {
            /*
    private float regenerateAmount = .5f;
    private float staminaRegenerateTime = 0.1f;
    private float losingAmount = 1;
    private float losingStaminaTime = 0.1f;*/

            //Regenerates stamina calculating the amount per second and multiplying it by time
            currentStamina -= (losingAmount/losingStaminaTime) *Time.deltaTime;

            //Resets the regeneration timer
            _staminaRegenDelayTimer = _secondsDelayBeforeStaminaRegen;



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
        else
        {
            // only if not pressing run start the regen timer
            if (_staminaRegenDelayTimer > 0)
            {
                _staminaRegenDelayTimer -= Time.deltaTime;
            }
            else
            {
                // once timer is finished start regen
                currentStamina += _staminaRegenPerSecond * Time.deltaTime;
            }
        }
        /*
        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            staminaSlider.RecoverStamina();
        }
    }*/
    }
    private void UpdateStamina()
    {
        if (true)//_inputManager.IsRunning)
        {
            // drain your stamina -> also informs all listeners
            currentStamina -= _staminaDrainPerSecond * Time.deltaTime;

            // reset the regen timer
            _staminaRegenDelayTimer = _secondsDelayBeforeStaminaRegen;
        }
        else
        {
            // only if not pressing run start the regen timer
            if (_staminaRegenDelayTimer > 0)
            {
                _staminaRegenDelayTimer -= Time.deltaTime;
            }
            else
            {
                // once timer is finished start regen
                currentStamina += _staminaRegenPerSecond * Time.deltaTime;
            }
        }
    }
}
