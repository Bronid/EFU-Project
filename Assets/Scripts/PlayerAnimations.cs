using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerAnimations : MonoBehaviour
{

    private Animator anim;
    private CharacterController controller;


    void Start()
    {
        anim = GetComponent<Animator>();
        controller = GetComponent<CharacterController>();
    }

    void Update()
    {
        if (SwipeController.swipeRight)
        {
            anim.SetTrigger("Right");
        }
        else
        {
            anim.SetBool("isRunning", true);
        }

        if (SwipeController.swipeLeft)
        {
            anim.SetTrigger("Left");
        }
        else
        {
            anim.SetBool("isRunning", true);
        }

        if (SwipeController.swipeUp)
        {
            anim.SetTrigger("Jump");
        }
        else
        {
            anim.SetBool("isRunning", true);
        }

        if (SwipeController.swipeDown)
        {
            anim.SetTrigger("Slide");
        }
        else
        {
            anim.SetBool("isRunning", true);
        }
    }
}
