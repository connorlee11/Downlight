using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmbientSoundTimer : MonoBehaviour
{
    public float soundTimer = 40f;

    public AK.Wwise.Event playStinger01;


    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating ("PlaySound", soundTimer, soundTimer);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void PlaySound()
    {
        playStinger01.Post(gameObject);
    }

}
