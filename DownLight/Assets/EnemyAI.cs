using UnityEngine;
using System.Collections;
using Pathfinding;

[RequireComponent (typeof (Rigidbody2D))]
[RequireComponent (typeof (Seeker))]
public class EnemyAI : MonoBehaviour {

	// What to chase?
	public Transform target;
	
	// How many times each second we will update our path
	public float updateRate = 2f;

	// Bright Light Collider
	private PolygonCollider2D poly;
	
	// Caching
	private Seeker seeker;
	private Rigidbody2D rb;
	
	//The calculated path
	public Path path;
	
	//The AI's speed per second
	public float speed = 50f;
	public ForceMode2D fMode;
	 
	[HideInInspector]
	public bool pathIsEnded = false;
	
	// The max distance from the AI to a waypoint for it to continue to the next waypoint
	public float nextWaypointDistance = 3;
	
	// The waypoint we are currently moving towards
	private int currentWaypoint = 0;

	private bool searchingForPlayer = false;

	//Flip Sprite
	public Transform enemyGFX;
	
	void Start () {
		seeker = GetComponent<Seeker>();
		rb = GetComponent<Rigidbody2D>();
		
		if (target == null) {
		
			if (!searchingForPlayer) {
				searchingForPlayer = true;
				StartCoroutine (SearchForPlayer());
			}

			return;
		}
		
		// Start a new path to the target position, return the result to the OnPathComplete method
		seeker.StartPath (transform.position, target.position, OnPathComplete);
		
		StartCoroutine (UpdatePath ());
	}

	IEnumerator SearchForPlayer () {
		GameObject sResult = GameObject.FindGameObjectWithTag ("Player");
		if (sResult == null) {
			yield return new WaitForSeconds ( 0.5f );
			StartCoroutine (SearchForPlayer());
		} else {
			target = sResult.transform;
			searchingForPlayer = false;
			StartCoroutine (UpdatePath());
			yield return false;
		}
	}
	
	IEnumerator UpdatePath () {
		if (target == null) {
			if (!searchingForPlayer) {
				searchingForPlayer = true;
				StartCoroutine (SearchForPlayer());
			}
			 yield return false;
		}
		
		// Start a new path to the target position, return the result to the OnPathComplete method
		seeker.StartPath (transform.position, target.position, OnPathComplete);
		
		yield return new WaitForSeconds ( 1f/updateRate );
		StartCoroutine (UpdatePath());
	}
	
	public void OnPathComplete (Path p) {
		Debug.Log ("We got a path. Did it have an error? " + p.error);
		if (!p.error) {
			path = p;
			currentWaypoint = 0;
		}
	}
	
	void FixedUpdate () {
		if (target == null) {
			if (!searchingForPlayer) {
				searchingForPlayer = true;
				StartCoroutine (SearchForPlayer());
			}
			return;
		}
		
		//TODO: Always look at player?
		
		if (path == null)
			return;
		
		if (currentWaypoint >= path.vectorPath.Count) {
			if (pathIsEnded)
				return;
			
			Debug.Log ("End of path reached.");
			pathIsEnded = true;
			return;
		}
		pathIsEnded = false;
	
		Vector2 direction = ((Vector2)path.vectorPath[currentWaypoint] - rb.position).normalized;
		Vector2 force = direction * speed * Time.deltaTime;

		rb.AddForce(force);

		float distance = Vector2.Distance(rb.position, path.vectorPath[currentWaypoint]);

		if (distance < nextWaypointDistance) {
			currentWaypoint++;
		}

		if (rb.velocity.x >= 0.01f){
          enemyGFX.localScale = new Vector3(-0.3f, 0.3f, 0.3f);
		 } 
			else if (rb.velocity.x <= -0.01f){
          enemyGFX.localScale = new Vector3(0.3f, 0.3f, 0.3f);
		 }
	}

	// Makes the enemy slow when in bright light.
	private void OnTriggerEnter2D(Collider2D poly)
    {
        if (poly.tag == "Light")
        {
            speed = speed = -15;
         
        }
    }

	private void OnTriggerExit2D(Collider2D poly)
    {
        if (poly.tag == "Light")
        {
            speed = speed = 50;
         
        }
    }
	
}