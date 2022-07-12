using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public AK.Wwise.Event stop;



    void Awake()
    {
        AkSoundEngine.SetRTPCValue("Sound_Fade", 0);
        AkSoundEngine.SetRTPCValue("GameOver", 10);
        AkSoundEngine.SetRTPCValue("MusicVolume", 75);
        AkSoundEngine.SetRTPCValue("SFXVolume", 100);
    }

   public void PlayGame ()
   {
       AkSoundEngine.SetRTPCValue("Sound_Fade", 10);
       
       SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
       StartCoroutine("StopAllSounds");
       //Debug.Log("Music Stopped!");

   }

   public void QuitGame ()
   {
       Debug.Log("QUIT!");
       Application.Quit();
   }


    IEnumerator StopAllSounds()
   {
       yield return new WaitForSeconds(10);
       Debug.Log("Music Stopped!");
       stop.Stop(gameObject);
   }

}
