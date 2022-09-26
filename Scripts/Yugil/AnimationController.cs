using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationController : MonoBehaviour
{
    private Animator animator;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            animator.Play("Paddling");
        }
        else if(Input.GetKey(KeyCode.A))
        {
            animator.Play("Paddling");
        }
        else if(Input.GetKey(KeyCode.D))
        {
            animator.Play("Paddling");
        }
        else if(Input.GetKey(KeyCode.S))
        {
            animator.Play("Paddling");
        }
        else
        {
            animator.Play("Idle");
        }
    }
}
