using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoPickup : MonoBehaviour
{
	private Weapon weapon;
	public GameObject player;



	

	private void Awake ()
	{
		weapon = player.GetComponent<Weapon>();
	}
   

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.tag == "Player")
		{
			Destroy(gameObject);
		}
	}

}
