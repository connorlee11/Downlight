using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

public class LightBrighten : MonoBehaviour
{
     LightToggle lT;

     //public GameObject staminaBar;

     public Light2D light;
     public Light2D worldLight;

     public bool brighten;

    //Wwise Stuff
     public AK.Wwise.Event brightenSound;
     public AK.Wwise.Event breakSound;

    [SerializeField] PolygonCollider2D Bright;
    //[SerializeField] GameObject flashlight;

    // Start is called before the first frame update
    void Start()
    {
        Bright = GetComponent<PolygonCollider2D>();
 
    }

    void OnEnable()
    {
        if (Bright.enabled = Bright.enabled)
        {
          Bright.enabled = !Bright.enabled;
            
        }
    
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire2") && StaminaBar.instance.currentStamina > 1)
        {
            brightenSound.Post(gameObject);
            brighten = true;
            //Debug.Log("Trigger 01");
            light.pointLightOuterAngle = 55;
            StartCoroutine(lightUp());
            AkSoundEngine.SetRTPCValue("LightBrighten", 100);
            light.intensity = 11;
            //worldLight.intensity = 0;

        } else if(Input.GetButtonUp("Fire2") || StaminaBar.instance.currentStamina <= 0)
            {
                brightenSound.Stop(gameObject);
                brighten = false;
                //Debug.Log("Trigger 02");
                light.pointLightOuterAngle = 70;
                Bright.enabled = false;
                AkSoundEngine.SetRTPCValue("LightBrighten", 0);
                light.intensity = 3;
                //worldLight.intensity = 0.4f;
            }   

            if (Input.GetMouseButton(1))
            {
                StartCoroutine(StaminaBar.instance.UseStamina(1));
                //Debug.Log("Trigger 03");
            }  

            if (brighten = true && StaminaBar.instance.currentStamina == 10)
            {
                breakSound.Post(gameObject);
            }

    }
    IEnumerator lightUp ()
    {
            // if (lT.FlashLightActive == true)
                  Bright.enabled = !Bright.enabled;
                  yield return null;
    }

}
