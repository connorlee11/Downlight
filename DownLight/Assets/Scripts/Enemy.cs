using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int health = 100;

    public Transform itemPrefab;
    public Transform attackPrefab;

    public GameObject deathEffect;

    public Transform deathLocation;
    public Transform deathEffectLocation;
    const float dropRate = 1f / 4f;

    [SerializeField] private float attackDamage = 50f;
     [SerializeField] private float attackSpeed = 1f;
     private float canAttack;
     
     public Animator animator;
     //public ParticleSystem death;

     [Header("Wwise Events")]
    public AK.Wwise.Event stop;
    public AK.Wwise.Event attack;
    public AK.Wwise.Event playerHitSound;
    public AK.Wwise.Event deathSound;

  

    private void OnTriggerStay2D(Collider2D other) {
        if (other.gameObject.tag == "Player") {
            animator.SetBool("IsAttacking", true);
            if (attackSpeed <= canAttack){
                Debug.Log("Is Attacking");
                Instantiate (attackPrefab, deathLocation.position, deathLocation.rotation);
                playerHitSound.Post(gameObject);
                other.gameObject.GetComponent<PlayerHealth>().UpdateHealth(-attackDamage);
            canAttack = 0f;
            } else{
                canAttack += Time.deltaTime;
            }
        }

    }
    private void OnTriggerExit2D(Collider2D other){
            if (other.gameObject.tag == "Player") {
                animator.SetBool("IsAttacking", false);
            }
        }

    public void TakeDamage (int damage)
    {
        health -= damage;

        if (health <= 0)
        {
            Die();
        }
    }

    public void Die ()
    {
        stop.Stop(gameObject);
        deathSound.Post(gameObject);
        Instantiate (deathEffect, deathEffectLocation.position, deathEffectLocation.rotation);
        Destroy(gameObject);
        //death.Play();
        if (Random.Range(0f, 1f) <= dropRate)
        {
             Instantiate (itemPrefab, deathLocation.position, deathLocation.rotation);
        }
       // Instantiate (itemPrefab, deathLocation.position, deathLocation.rotation);
    }
 
}
