using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeVolumeLevel : MonoBehaviour
{
    public Slider thisSlider;
    //public float masterVolume;
    public float musicVolume;
    public float SFXVolume;

    // Start is called before the first frame update
    void Awake()
    {
            //AkSoundEngine.SetRTPCValue("MusicVolume", thisSlider.value);
            //AkSoundEngine.SetRTPCValue("SFXVolume", thisSlider.value);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetSpecificVolume(string whatValue)
    {
        float sliderValue = thisSlider.value;

        if (whatValue == "Music")
        {
            //Debug.Log("Change music volume to :" + thisSlider.value);
            musicVolume = thisSlider.value;
            AkSoundEngine.SetRTPCValue("MusicVolume", musicVolume);
        }

         if (whatValue == "Game")
        {
            //Debug.Log("Change music volume to :" + thisSlider.value);
            SFXVolume = thisSlider.value;
            AkSoundEngine.SetRTPCValue("SFXVolume", SFXVolume);
        }
    }


}
