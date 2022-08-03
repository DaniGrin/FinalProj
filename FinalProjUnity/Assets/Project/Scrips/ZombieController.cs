using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ZombieController : MonoBehaviour
{
    private bool _isGrounded;
    private Vector3 _velocity;
    private float _zombieSpeed;

    [SerializeField] private Transform GroundCheck;
    [SerializeField] private float GroundDistance = 0.4f;
    [SerializeField] private LayerMask GroundMask;

    [SerializeField] private NavMeshAgent Agent = null;
    [SerializeField] private Transform target;

    void Start()
    {
        
        _zombieSpeed = Agent.speed;
    }

    void Update()
    {
        _isGrounded = Physics.CheckSphere(GroundCheck.position, GroundDistance, GroundMask);

        if (_isGrounded && _velocity.y < 0)
        {
            _velocity.y = -2f;
        }
        bool isZombieOnRange = transform.position.x - target.position.x <= 12 && transform.position.x - target.position.x > 0 || target.position.x - transform.position.x <= 12 && target.position.x - transform.position.x > 0;
        if (isZombieOnRange)
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
        Agent.speed = 0;
    }

    private void MoveToTarget()
    {
        Agent.SetDestination(target.position);
        RotateToTarget();
        Agent.speed = _zombieSpeed;

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
    
}
