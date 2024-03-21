using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class StaminaBar : MonoBehaviour
{

    public Slider staminaSlider;
    private PlayerMovement playerMovement;


    private float currentStamina;
    private float staminaRegenerateTime = 0.1f;

    private float regenerateAmount = .5f;
    private float losingAmount = 1;



    private float losingStaminaTime = 0.1f;

    private Coroutine losingStaminaCoroutine;
    private Coroutine regeneratingCorutine;



    private void Awake()
    {
        // or wherever you get the reference from
        if (!playerMovement) playerMovement = FindObjectOfType<PlayerMovement>();

        // poll the setting from the player
        staminaSlider.maxValue = playerMovement.MaxStamina;

        // attach a callback to the event 
        playerMovement.OnStaminaChanged.AddListener(OnStaminaChanged);

        // just to be sure invoke the callback once immediately with the current value
        // so we don't have to wait for the first actual event invocation
        OnStaminaChanged(playerMovement.currentStamina);
    }

    private void OnDestroy()
    {
        if (playerMovement) playerMovement.OnStaminaChanged.RemoveListener(OnStaminaChanged);
    }

    // This will now be called whenever the stamina has changed
    private void OnStaminaChanged(float stamina)
    {
        staminaSlider.value = stamina;
    }

    // Start is called before the first frame update
    void Start()
    {
        currentStamina = maxStamina;
        staminaSlider.maxValue = maxStamina;
        staminaSlider.value = maxStamina;
    }

    internal void SetSliderPosition(float amount)
    {
        currentStamina = amount;
        staminaSlider.value = currentStamina;
    }

    public void RecoverStamina()
    {
        //Stops losing stamina
        if (losingStaminaCoroutine != null){ StopCoroutine(losingStaminaCoroutine); }

        //Starts regeneating
        regeneratingCorutine = StartCoroutine(RecoveringStaminaCorutine());
    }
    private IEnumerator RecoveringStaminaCorutine()
    {
        //Wait a couple seconds before starting recovering
        yield return new WaitForSeconds(1.5f);

        //Recovers while it can incrementing slowly
        while (currentStamina < maxStamina)
        {
            currentStamina += regenerateAmount;
            staminaSlider.value = currentStamina;
            yield return new WaitForSeconds(staminaRegenerateTime);
        }

        regeneratingCorutine = null;
    }


    /*
     * Method called from player controller on stamina button pressed
     */
    public void UseStamina(float amount)
    {
        losingAmount = amount;
        //Cancell regeneration while using stamina
        if (regeneratingCorutine != null) { StopCoroutine(regeneratingCorutine); }


        //The stamina is spent while it's not 0
        losingStaminaCoroutine = StartCoroutine(LosingStaminaCoroutine());

        //When the stamina is 0 we start regenerating
        if (currentStamina <= 0)
        {
            RecoverStamina();
        }
    }

    private IEnumerator LosingStaminaCoroutine()
    {
        //Loses stamina while it can
        while ((currentStamina - losingAmount > 0) && (Input.GetAxis("Horizontal")+Input.GetAxis("Vertical")!=0))
        {
            yield return new WaitForSeconds(0.1f);


            currentStamina -= losingAmount;
            SetSliderPosition(currentStamina);
        }
    }



    /*  public void Use_Stamina(float amount)
  {
      //If player has stamina
      if (currentStamina - amount > 0)
      {
          if (losingStaminaCoroutine != null)
          {
              StopCoroutine(losingStaminaCoroutine);
          }
          losingStaminaCoroutine = StartCoroutine(LosingStaminaCoroutine(amount));

          if (regeneratingCorutine != null)
          {
              StopCoroutine(regeneratingCorutine);
          }
          regeneratingCorutine = StartCoroutine(RegenerateStaminaCoroutine());
      }
      else
      {
          FindObjectOfType<PlayerMovement>().isSprinting = false;
      }
  }

  private IEnumerator Losing_StaminaCoroutine(float amount)
  {

      float x = Input.GetAxis("Horizontal");
      float z = Input.GetAxis("Vertical");
      while (currentStamina >= 0 && (x != 0 || z != 0))
      {
          x = Input.GetAxis("Horizontal");
          z = Input.GetAxis("Vertical");

          currentStamina -= amount;
          staminaSlider.value = currentStamina;
          yield return new WaitForSeconds(losingStaminaTime);
      }
      losingStaminaCoroutine = null;
      FindObjectOfType<PlayerMovement>().isSprinting = false;
      FindObjectOfType<PlayerMovement>().sprintSpeed = 1;
  }

  private IEnumerator RegenerateStaminaCoroutine()
  {
      yield return new WaitForSeconds(1);
      while (currentStamina < maxStamina)
      {
          currentStamina += regenerateAmount;
          staminaSlider.value = currentStamina;
          yield return new WaitForSeconds(staminaRegenerateTime);
      }
      regeneratingCorutine = null;
  }

  /*
    private IEnumerator LoseStaminaCoroutine()
   {
       yield return new WaitForSeconds(1);

       //The stamina must be equal to the current stamina plus the healing amount
       float recoveredValue = currentStamina + healingAmount;

       //We save the current stamina as player can deal damage while recovering
       float lifeWhenHealing = currentStamina;

       //That stamina is reached steadly
       while (lifeWhenHealing < recoveredValue)
       {
           lifeWhenHealing += regenerateAmount;
           currentStamina += regenerateAmount;

           //Set new stamina on player Controller
           player.GetComponent<PlayerInteraction>().stamina = currentStamina;
           SetSliderPosition(currentStamina);

           yield return new WaitForSeconds(StaminaRegenerateTime);
       }
       mCoroutineRegenerate = null;
   }

      private IEnumerator RegenerateStaminaCoroutine(float healingAmount)
  {
      yield return new WaitForSeconds(1);

      //The stamina must be equal to the current stamina plus the healing amount
      float recoveredValue = currentStamina + healingAmount;

      //We save the current stamina as player can deal damage while recovering
      float lifeWhenHealing = currentStamina;

      //That stamina is reached steadly
      while (lifeWhenHealing < recoveredValue)
      {
          lifeWhenHealing += regenerateAmount;
          currentStamina += regenerateAmount;

          //Set new stamina on player Controller
         // player.GetComponent<PlayerInteraction>().stamina = currentStamina;
          SetSliderPosition(currentStamina);

          yield return new WaitForSeconds(staminaRegenerateTime);
      }
      regeneratingCorutine = null;
  }*/
}
