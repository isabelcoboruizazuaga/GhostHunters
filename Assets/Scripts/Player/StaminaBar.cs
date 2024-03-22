using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class StaminaBar : MonoBehaviour
{

    public Slider staminaSlider;
    private float currentStamina;
    const float MAXSTAMINA = 100;

    private float staminaRegenerateTime = 0.2f;
    private float regenerateAmount = .5f;

    private float losingAmount = 1;
    private float losingStaminaTime = 0.1f;


    public GameObject player;

    private Coroutine losingStaminaCoroutine;
    private Coroutine regeneratingCorutine;


    // Start is called before the first frame update
    void Awake()
    {
        currentStamina = MAXSTAMINA;
        staminaSlider.maxValue = MAXSTAMINA;
        staminaSlider.value = MAXSTAMINA;
    }

    internal void SetSliderPosition(float amount)
    {
        currentStamina = amount;
        staminaSlider.value = currentStamina;
    }

    public void RecoverStamina()
    {
        if (losingStaminaCoroutine != null)
        {
            StopCoroutine(losingStaminaCoroutine);
        }

        //Starts regeneating
        regeneratingCorutine = StartCoroutine(RecoveringStaminaCorutine());
    }
    private IEnumerator RecoveringStaminaCorutine()
    {
        //Waits a couple seconds before starting recovering
        yield return new WaitForSeconds(1.5f);

        //Recovers while it can incrementing slowly
        while (currentStamina < MAXSTAMINA)
        {
            currentStamina += regenerateAmount;
            staminaSlider.value = currentStamina;
            yield return new WaitForSeconds(staminaRegenerateTime);
        }

        //Stops regenerating when stamina its full
        StopCoroutine(regeneratingCorutine);
        regeneratingCorutine = null;
    }


    /*
     * Method called from player controller on stamina button pressed
     */
    public void UseStamina()
    {
        //Cancell regeneration while using stamina
        if (regeneratingCorutine != null) StopCoroutine(regeneratingCorutine);

        losingStaminaCoroutine = StartCoroutine(LosingStaminaCoroutine());
    }

    private IEnumerator LosingStaminaCoroutine()
    {
        //Loses stamina while it can
        while ((currentStamina - losingAmount > 0) && (Input.GetAxis("Horizontal") > 0.09 || Input.GetAxis("Vertical") > 0.09))
        {
            yield return new WaitForSeconds(losingStaminaTime);
            currentStamina -= losingAmount;
            SetSliderPosition(currentStamina);
        }
        //When the stamina is 0 we start regenerating
        RecoverStamina();
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
