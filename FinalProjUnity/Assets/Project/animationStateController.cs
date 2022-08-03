using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class animationStateController : MonoBehaviour
{
    Animator animator;
    int isWalkingHash;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        isWalkingHash = Animator.StringToHash("isWalking");
    }

    // Update is called once per frame
    void Update()
    {
        bool isWalking = animator.GetBool(isWalkingHash);
        bool forwardPressed = Input.GetKey("w");
        if( forwardPressed)
        {
            animator.SetBool(isWalkingHash,true);
            animator.Play("Walking");
        }
        if (!forwardPressed)
        { 
            animator.SetBool(isWalkingHash,false);
            //animator.Play("Idle");
        }
    }
}
