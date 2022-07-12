using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaySound : MonoBehaviour
{
    [Header("Wwise Events")]
    public AK.Wwise.Event play;
    public AK.Wwise.Event play2;


    void Start()
    {
        AkSoundEngine.RegisterGameObj(gameObject);
    }

    void Play()
    {
        play.Post(gameObject);
    }

    public void Play2()
    {
        play2.Post(gameObject);
    }


}
