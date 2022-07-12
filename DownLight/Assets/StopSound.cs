using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopSound : MonoBehaviour
{
     [Header("Wwise Events")]
    public AK.Wwise.Event stop;
    public AK.Wwise.Event stop2;
  

    // Update is called once per frame
    public void SoundStop()
    {
        stop.Stop(gameObject);
        stop2.Stop(gameObject);
    }
}
