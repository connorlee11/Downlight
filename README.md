<p align="center">
  <img src="https://i.imgur.com/nPsqSua.png">
</p>

<h1 align="center">Downlight</h1>

<div style="text-align: center">This is a 2D side scroller that I made as a way to improve my C# coding and game development skills.</div>
 <br />

 <p align="center"><img src="https://img.shields.io/github/last-commit/connorlee11/Downlight"> <img src="https://img.shields.io/github/directory-file-count/connorlee11/Downlight"> <img src="https://img.shields.io/discord/996873491779424276?color=red&label=Discord"></p> 
 <br />


<p align="center">
  <img src="https://media.giphy.com/media/clZUPN84jELxYouMVd/giphy.gif">
</p>

 <h1 align="center">Download</h1>

 <div style="text-align: center">If you want to give the game a try, you can download it here: <a href="https://drive.google.com/file/d/1oWp-wBEIWnkTbo9jcmSWaJCXIyDzU1yH/view?usp=sharing" target="_blank">Downlight</a></div>
<br />
<br />
<br />
<br />

<h1 align="center">Game Mechanics</h1>
<h2 align="left">Flashlight Toggle</h2>
<br />


<div style="text-align: left">The game features a flashlight brighten feature that slows down enemies when left-click is held down. While the light is in the brightened state it slowly drains the energy bar on the bottom left corner of the HUD. This feature was inspired by the flashlight mechanic from the game Alan Wake. As the game progresses in rounds, the need to conserve and use the energy wisely is paramount.
<br />
<br />


```c#
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
            

        } else if(Input.GetButtonUp("Fire2") || StaminaBar.instance.currentStamina <= 0)
            {
                brightenSound.Stop(gameObject);
                brighten = false;
                //Debug.Log("Trigger 02");
                light.pointLightOuterAngle = 70;
                Bright.enabled = false;
                AkSoundEngine.SetRTPCValue("LightBrighten", 0);
                light.intensity = 3;
                
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
```



 <h2 align="left">Healing Light</h2>
<br />

<div style="text-align: left">Another mechanic that was inspired by Alan Wake was the healing mechanic. The player begins to recharge health as long as they are standing in the light. I achieved this by adding a box collider component set as a trigger to the Lantern asset. When the trigger senses an object with the tag "Player" it starts the coroutine named "Heal". 
<br />
<br />


```c#
 void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            Debug.Log("Entered Light!");
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
```


 <h2 align="left">RNG Ammo Drops</h2>
<br />

<div style="text-align: left">Downlight is as much a game of luck as it is a game of skill. The enemies have a 1/4 chance of dropping ammo when you kill them. This mechanic makes conserving ammo a necessity if you plan on getting anywhere past round five. If your RNG is bad then you are forced to rely on the two ammo spawns on either side of the map. These only respawn every thirty seconds however.   
<br />
<br />

```c#
const float dropRate = 1f / 4f;
```

```c#
 public void Die ()
    {
        stop.Stop(gameObject);
        deathSound.Post(gameObject);
        Instantiate (deathEffect, deathEffectLocation.position, deathEffectLocation.rotation);
        Destroy(gameObject);
        if (Random.Range(0f, 1f) <= dropRate)
        {
             Instantiate (itemPrefab, deathLocation.position, deathLocation.rotation);
        }
    }
```


<h1 align="center">Video</h1>





 



