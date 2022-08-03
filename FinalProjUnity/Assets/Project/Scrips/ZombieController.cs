using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ZombieController : MonoBehaviour
{
    bool isGrounded;
    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;
    Vector3 velocity;
    public NavMeshAgent agent = null;
    [SerializeField] private Transform target;

    void Start()
    {
        //GetReference();
    }

    void Update()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }
        if (transform.position.x - target.position.x <= 12 && transform.position.x - target.position.x > 0 || target.position.x - transform.position.x <= 12 && target.position.x - transform.position.x > 0)
        {
            MoveToTarget();
        }
        else
        {
            Stop();
        }
            
    }

    private void Stop()
    {
        agent.speed = 0;
    }

    private void MoveToTarget()
    {
        agent.SetDestination(target.position);
        RotateToTarget();
        agent.speed = 1;

    }
    private void RotateToTarget()
    {
        var targetPosition = target.position;
        targetPosition.y = transform.position.y;
        transform.LookAt(targetPosition);
        
        //Vector3 direction = target.position - transform.position;
        //Quaternion rotation = Quaternion.LookRotation(direction, Vector3.up);
        //transform.rotation = rotation;
    }
    private void GetReference()
    {
        agent = GetComponent<NavMeshAgent>();
    }
}
