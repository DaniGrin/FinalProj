using Project.Scrips.Weapon;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//this class allowd to animate any of the player's movement and actions
//the functions below activates and pause the animate by buttons that pressed as a trigger
public class animationState : MonoBehaviour
{
    [SerializeField] private WeaponHolder _playerWeaponHolder;
    Animator animator;
    int isWalkingHash;
    int isRunningHash;
    int isJumpingHash;
    int isIdleCrouchingHash;
    int isHookingHash;
    int isHoldWeaponHash;


    void Start()
    {
        animator = GetComponent<Animator>();
        isWalkingHash = Animator.StringToHash("isWalking");
        isRunningHash = Animator.StringToHash("isRunning");
        isJumpingHash = Animator.StringToHash("isJumping");
        isIdleCrouchingHash = Animator.StringToHash("isIdleCrouching");
        isHookingHash = Animator.StringToHash("isHookPunch");
        isHoldWeaponHash = Animator.StringToHash("isHoldWeapon");
    }

    // Update is called once per frame
    void Update()
    {
        bool isrunning = animator.GetBool(isRunningHash);
        bool isWalking = animator.GetBool(isWalkingHash);
        bool forwardPressed = Input.GetKey("w");
        bool RunPressed = Input.GetKey("left shift");
        bool jump = Input.GetKey("space");
        bool idleCrouching = Input.GetKey("left ctrl");
        bool punch = Input.GetKey(KeyCode.Mouse0);
        bool holdWeapon = _playerWeaponHolder.isHoldWeapon;

        if (holdWeapon && punch)
        {
            animator.SetBool(isHookingHash, false);
            animator.SetBool(isHoldWeaponHash, true);
        }
        if(!holdWeapon || !punch)
        {
            animator.SetBool(isHoldWeaponHash, false);
        }
        if (!isWalking && forwardPressed)
        {
            //set the isWalking boolean to true
            animator.SetBool(isWalkingHash, true);
        }
        if (isWalking && !forwardPressed)
        {
            //set the isWalking boolean to true
            animator.SetBool(isWalkingHash, false);
        }
        if (!punch)
        {
            //set the isWalking boolean to true
            animator.SetBool(isHookingHash, false);
        }
        if (punch)
        {
            //set the isWalking boolean to true
            animator.SetBool(isHookingHash, true);
        }
        //if player is walking and not running and presses left shift
        if (!isrunning && (forwardPressed && RunPressed))
        {
            //then set the isRunning boolean to be true
            animator.SetBool(isRunningHash, true);

        }
        if (isrunning && (!forwardPressed || !RunPressed))
        {

            animator.SetBool(isRunningHash, false);
        }
        if (jump || jump && isWalking || jump && isrunning)
        {
            animator.SetBool(isJumpingHash, true);

        }
        if (!jump)
        {
            animator.SetBool(isJumpingHash, false);
        }
        if (idleCrouching)
        {
            animator.SetBool(isIdleCrouchingHash, true);
        }
        if (!idleCrouching)
        {
            animator.SetBool(isIdleCrouchingHash, false);
        }
        
    }
}
