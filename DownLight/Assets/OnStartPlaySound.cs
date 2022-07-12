using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnStartPlaySound : MonoBehaviour
{
    public AK.Wwise.Event play;

    // Start is called before the first frame update
    void Start()
    {
        Post();
    }

    // Update is called once per frame
    void Post()
    {
        play.Post(gameObject);
    }
}
