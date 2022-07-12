using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoSpawner : MonoBehaviour
{
    public GameObject ammoPrefab;
    public Transform ammoSpot01;
    public Transform ammoSpot02;

    public float ammoTimer = 3f;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating ("GiveAmmo", ammoTimer, ammoTimer);
    }

    // Update is called once per frame
    void GiveAmmo()
    {
           Instantiate (ammoPrefab, ammoSpot01.position, ammoSpot01.rotation);
           Instantiate (ammoPrefab, ammoSpot02.position, ammoSpot02.rotation); 
    }
}
