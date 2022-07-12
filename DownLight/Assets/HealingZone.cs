using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealingZone : MonoBehaviour
{
    public PlayerHealth playerHealth;

    public HealthBar healthBar;

    //public ParticleSystem healingEffect;


    void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            //Debug.Log("Entered Light!");
            StartCoroutine(Heal());
        }
    }

     void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            Debug.Log("Left the Light!");
            StopCoroutine(Heal());
        }
    }

    IEnumerator Heal()
    {
        if (playerHealth.health < 100f)
        {
            playerHealth.health += 0.1f;
            yield return new WaitForSeconds(Time.deltaTime);
            healthBar.SetHealth (playerHealth.health);
        }
        
    }

}
