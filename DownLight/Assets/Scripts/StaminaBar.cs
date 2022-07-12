using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StaminaBar : MonoBehaviour
{

    public Slider staminaBar;

    private float maxStamina = 600;
    public float currentStamina;

    private WaitForSeconds regenTick = new WaitForSeconds(0.1f);
    private Coroutine regen;

    public const float staminaDrain = 50f;

    public static StaminaBar instance;

    private void Awake()
    {
        instance = this;
    } 


    // Start is called before the first frame update
    void Start()
    {
        currentStamina = maxStamina;
        staminaBar.maxValue = maxStamina;
        staminaBar.value = maxStamina;
    }

    public IEnumerator UseStamina(float staminaDrain)
    {
        if(currentStamina - staminaDrain >= 0)
        {
            currentStamina -= 5f;
            yield return null;
            staminaBar.value = currentStamina;

            if(regen != null)
                StopCoroutine(regen);

            regen = StartCoroutine(StaminaRegen());
        }
        else
        {
            //Debug.Log("No Stamina!");
        }
    }

    private IEnumerator StaminaRegen()
    {
        yield return new WaitForSeconds(1);

        while(currentStamina < maxStamina)
        {
            currentStamina += maxStamina / 50;
            staminaBar.value = currentStamina;
            yield return regenTick;
        }
        regen = null;
    }

    
}
