using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class animationState : MonoBehaviour
{
    Animator animator;
    int isWalkingHash;
    int isRunningHash;
    void Start()
    {
        animator = GetComponent<Animator>();
        isWalkingHash = Animator.StringToHash("isWalking");
        isRunningHash = Animator.StringToHash("isRunning");
    }

    // Update is called once per frame
    void Update()
    {
        bool isrunning = animator.GetBool(isRunningHash);
        bool isWalking = animator.GetBool(isWalkingHash);
        bool forwardPressed = Input.GetKey("w");
        bool RunPressed = Input.GetKey("left shift");
        if(!isWalking && forwardPressed)
        {
            //set the isWalking boolean to true
            animator.SetBool(isWalkingHash, true);
        }
        if (isWalking && !forwardPressed)
        {
            //set the isWalking boolean to true
            animator.SetBool(isWalkingHash, false);
        }

        //if player is walking and not running and presses left shift
        if(!isrunning && (forwardPressed && RunPressed))
        {
            //then set the isRunning boolean to be true
            animator.SetBool(isRunningHash, true);
        }
        if (isrunning &&(!forwardPressed || !RunPressed))
        {
            
            animator.SetBool(isRunningHash, false);
        }
    }
}
