using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationCode : MonoBehaviour
{
    public Rigidbody2D rigidBody;
    public Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        //rigidBody = GetComponent<Rigidbody2D>();
        //playerAnimation = GetComponentInChildren<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        animator.SetFloat("Speed", Mathf.Abs (rigidBody.velocity.x));
        
    }
}
