using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StaminaBar : MonoBehaviour
{

    public Slider staminaSlider;
    private float currentStamina;
    public float maxStamina = 100;
    private float staminaRegenerateTime = 0.1f;

    private float regenerateAmount = .5f;
    private float losingAmount = 1;


    public GameObject player;



    private float losingStaminaTime = 0.1f;

    private Coroutine losingStaminaCoroutine;
    private Coroutine regeneratingCorutine;


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
        regeneratingCorutine = StartCoroutine(RecoveringStaminaCorutine());
    }
    private IEnumerator RecoveringStaminaCorutine()
    {
        yield return new WaitForSeconds(1f);
        while (currentStamina < maxStamina)
        {
            currentStamina += regenerateAmount;
            staminaSlider.value = currentStamina;
            yield return new WaitForSeconds(staminaRegenerateTime);
        }
        regeneratingCorutine = null;
        // mCoroutineRegenerate = StartCoroutine(RegenerateStaminaCoroutine(amount));
    }


    /*
     * Method called from player controller on stamina button pressed
     */
    public void UseStamina(float amount)
    {
        losingAmount = amount;
        //Cancell regeneration while using stamina
        StopCoroutine(regeneratingCorutine);

        //The stamina is spent while it's not 0
        while(currentStamina - losingAmount > 0)
        {
            losingStaminaCoroutine = StartCoroutine(LosingStaminaCoroutine());
        }

        //When the stamina is 0 we start regenerating
            RecoverStamina();

        /* if (currentStamina - losingAmount > 0)
        {
            //Keep losing stamina
        }
        else
        { //stop sprinting and wait to regenare stamina
            RecoverStamina();}*/
    }

    private IEnumerator LosingStaminaCoroutine()
    {
        
        //se resta la estamina
        currentStamina -= losingAmount;

        //se setea la estamina en la barra
        SetSliderPosition(currentStamina);


        //Perdemos estamina cada x segs
        yield return new WaitForSeconds(0.1f); //Cada x segs perdemos stamina

        //el while para repetir va fuera !!!!!!!!!!!!
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
