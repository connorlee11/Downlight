using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WwAmbientEmitterScript : MonoBehaviour
{
    public string EventName = "default";
    public string StopEvent = "default";
    private bool IsInCollider = false;

    // Start is called before the first frame update
    void Start()
    {
        AkSoundEngine.RegisterGameObj(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag != "Play Area" || IsInCollider) { return; }
        IsInCollider = true;
        AkSoundEngine.PostEvent(EventName, gameObject);
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag != "Play Area" || IsInCollider) { return; }
        AkSoundEngine.PostEvent(StopEvent, gameObject);
        IsInCollider = false;
    }

    private void OnTriggerStay2D(Collider2D other) 
    {
        Debug.Log("In play area!");
        if (other.tag != "Play Area" || IsInCollider) { return; }
        IsInCollider = true;
        AkSoundEngine.PostEvent(EventName, gameObject);
    }
}
