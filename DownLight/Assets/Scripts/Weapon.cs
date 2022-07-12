using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    AmmoUI ammoUI;
    public GameObject ammoCount;
    public GameObject muzzleFlash;
    public ParticleSystem muzzle;


    public Transform firePoint;
    public int damage = 20;
    public GameObject impactEffect;
    public LineRenderer lineRenderer;
    public LayerMask WorldLayer;

    [Header("Wwise Events")]
    public AK.Wwise.Event shoot;
    public AK.Wwise.Event noAmmo;
    public AK.Wwise.Event reload;
    public AK.Wwise.Event vocalCue;

    //public PauseMenu pm;

    

    
   [Header("Ammo")]
   public int remainingAmmo = 15;

   private void Awake ()
   {
       ammoUI = ammoCount.GetComponent<AmmoUI>();
   }

    void Start ()
    {
        ammoUI.currentAmmoCountText.text = remainingAmmo.ToString();
        lineRenderer.enabled = false;
        
    }
 
    

    // Update is called once per frame
    void Update() {


      if (Input.GetButtonDown("Fire1") && remainingAmmo > 0 && PauseMenu.GameIsPaused == false)
      {
          Debug.Log("BANG!");
         StartCoroutine(Shoot());
         remainingAmmo = remainingAmmo - 1;
         ammoUI.currentAmmoCountText.text = remainingAmmo.ToString();
         StartCoroutine(flash());
         muzzle.Play();
         CinemachineShake.Instance.ShakeCamera(0.01f, .1f);
         shoot.Post(gameObject);
      }
      
      if (Input.GetButtonDown("Fire1") && remainingAmmo <= 0)
      {
          noAmmo.Post(gameObject);
          vocalCue.Post(gameObject);
          Debug.Log("Click");
      }

    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        //if (collision.tag == "Ammo" && remainingAmmo <= 14)
        if (collision.tag == "Ammo")
        {
            reload.Post(gameObject);
            remainingAmmo = remainingAmmo = 15;
            ammoUI.currentAmmoCountText.text = remainingAmmo.ToString();
        }
    }


    IEnumerator Shoot ()
    {
      
        Physics2D.queriesHitTriggers = false;

        //Shooting Logic
       RaycastHit2D hitInfo = Physics2D.Raycast(firePoint.position, firePoint.right); //QueryTriggerInteraction.Ignore

       if (hitInfo)
       {
           Debug.Log(hitInfo.transform.name);
           
           Enemy enemy = hitInfo.transform.GetComponent<Enemy>();
           if (enemy != null)
           {
               enemy.TakeDamage(damage);
           }

           Instantiate(impactEffect, hitInfo.point, Quaternion.identity);

           lineRenderer.SetPosition(0, firePoint.position);
           lineRenderer.SetPosition(1, hitInfo.point);
       } else
       {
           lineRenderer.SetPosition(0, firePoint.position);
           lineRenderer.SetPosition(1, firePoint.position + firePoint.right * 100);
       }

       lineRenderer.enabled = true;

            yield return new WaitForSeconds(0.02f);

       lineRenderer.enabled = false;
       
    }

    IEnumerator flash ()
    {
        muzzleFlash.SetActive(true);
        yield return new WaitForSeconds (0.1f);
        muzzleFlash.SetActive(false );
    }
}   
