using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LifeBar : MonoBehaviour
{
    public Slider lifeSlider;
    private float currentLife;
    public float maxLife = 100;
    private float lifeRegenerateTime = 0.1f;
    private float regenerateAmount = .5f;

    private Coroutine mCoroutineRegenerate;

    public GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        currentLife = maxLife;
        lifeSlider.maxValue = maxLife;
        lifeSlider.value = maxLife;
    }

    internal void SetSliderPosition(float amount)
    {
        currentLife = amount;
        lifeSlider.value = currentLife;
    }

    internal void Heal(float amount)
    {

        mCoroutineRegenerate = StartCoroutine(RegenerateLifeCoroutine(amount));
    }


    private IEnumerator RegenerateLifeCoroutine(float healingAmount)
    {
        yield return new WaitForSeconds(1);
        
        //The life must be equal to the current life plus the healing amount
        float recoveredValue = currentLife + healingAmount;

        //We save the current life as player can deal damage while recovering
        float lifeWhenHealing=currentLife;

        //That life is reached steadly
        while (lifeWhenHealing < recoveredValue)
        {
            lifeWhenHealing += regenerateAmount;
            currentLife += regenerateAmount;

            //Set new life on player Controller
            player.GetComponent<PlayerInteraction>().life = currentLife;
            SetSliderPosition(currentLife);

            yield return new WaitForSeconds(lifeRegenerateTime);
        }
        mCoroutineRegenerate = null;
    }
}
