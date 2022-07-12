using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationTimer : MonoBehaviour
{
    public float animationTimer = 40f;

    public float animationStopTimer = 0.5f;
    public Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        animator.SetBool("PlayAnimation", false);
        InvokeRepeating ("PlayAnimation", animationTimer, animationTimer);
    }

    // Update is called once per frame
    void PlayAnimation()
    {
        animator.SetBool("PlayAnimation", true);
        Invoke ("StopAnimation", animationStopTimer);
    }

    void StopAnimation()
    {
        animator.SetBool("PlayAnimation", false);
    }
}
