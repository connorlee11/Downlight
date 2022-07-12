using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundController : MonoBehaviour
{
    [Header("Wwise Events")]
    public AK.Wwise.Event play;
    public AK.Wwise.Event stop;

    // void Awake()
    // {
    //     SoundPlay();
    // }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SoundPlay()
    {
        play.Post(gameObject);
    }

    public void SoundStop()
    {
        stop.Stop(gameObject);
    }
}
