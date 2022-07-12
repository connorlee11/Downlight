using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public float health = 0f;

    public HealthBar healthBar;

    public ParticleSystem healingEffect;

    public AK.Wwise.Event healSound;

    [SerializeField] private float maxHealth = 100f;



    public void Start (){
        health = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
        
    }

    public void UpdateHealth(float mod)
    {
        health += mod;
        healthBar.SetHealth(health);

        if (health > maxHealth)
        {
            health = maxHealth;
        } else if (health <= 0f)
        {   
            Debug.Log ("I died");
           GameMaster.KillPlayer(this);
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "HealingLight" && health < 100)
        {
            AkSoundEngine.SetRTPCValue("HealingLight_Fade", 10);
            Debug.Log("RTPC Change");
            healSound.Post(gameObject);
            healingEffect.Play();
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "HealingLight")
        {
            AkSoundEngine.SetRTPCValue("HealingLight_Fade", 0);
            healingEffect.Stop();
        }
    }

    void Update()
    {
        if (health >= 100)
        {
            AkSoundEngine.SetRTPCValue("HealingLight_Fade", 0);
            healingEffect.Stop();
        }
    }

}
