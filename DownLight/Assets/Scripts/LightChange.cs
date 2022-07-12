using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightChange : MonoBehaviour
{
   [SerializeField] Light myLight;

    // Start is called before the first frame update
    void Start()
    {
       myLight = GetComponent<Light>();
    }

    // Update is called once per frame
    void Update()
    {
       if (Input.GetMouseButton(1))
       {
           myLight.intensity = 1.0f;
           
       }
       else
       {
           myLight.intensity = 4.07f;
           
       }
    }
}
