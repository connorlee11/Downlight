using Pathfinding;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

    [RequireComponent (typeof (Rigidbody2D))]
    [RequireComponent (typeof (Seeker))]
public class EnemyAIMine : MonoBehaviour
{

    //what to chase?
    public Transform target;

    // How many times a second we will update our path
    public float updateRate = 2f;

    // catching
    private Seeker seeker;
    private Rigidbody2D rb;

    //The Calculated Path
    public Path path;

    //The AI Spped per second
    public float speed = 300f;
    public ForceMode2D fMode;

    [HideInInspector]
    public bool pathIsEnded = false;

    // the max distance from the AI to a waypoint for it to continue to the next waypoint
    public float nextWaypointDistance = 3;

    private int currentWaypoint = 0;

    void Start () {
        seeker = GetComponent<Seeker>();
        rb = GetComponent<Rigidbody2D>();

        if (target == null) {
            Debug.LogError ("No Player Found");
            return;
        }

        seeker.StartPath (transform.position, target.position, OnPathComplete);

        StartCoroutine (UpdatePath ());
    }

    IEnumerator UpdatePath () {
        if (target == null) {
            yield return null;
        }

        seeker.StartPath (transform.position, target.position, OnPathComplete);

        yield return new WaitForSeconds ( 1f/updateRate);
        StartCoroutine (UpdatePath());
    }

    public void OnPathComplete (Path p) {
        Debug.Log ("We got a path. did it have a error? " + p.error);
        if (!p.error) {
            path = p;
            currentWaypoint = 0;
        }
    }

    void FixedUpdate () {
        if (target == null) {
            return;
    }

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

       // direction to next waypoint
       Vector3 dir = ( path.vectorPath[currentWaypoint] - transform.position ).normalized;
       dir *= speed * Time.fixedDeltaTime;

       //Move the AI
       rb.AddForce (dir, fMode);

       float dist = Vector3.Distance (transform.position, path.vectorPath[currentWaypoint]);
       if (dist < nextWaypointDistance) {
           currentWaypoint++;
           return;
       }

    }
}
