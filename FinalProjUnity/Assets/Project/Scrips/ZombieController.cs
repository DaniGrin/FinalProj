using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ZombieController : MonoBehaviour
{
    private bool _isGrounded;
    public Transform GroundCheck;
    public float GroundDistance = 0.4f;
    public LayerMask GroundMask;
    private Vector3 _velocity;
    private float _zombieSpeed;
    public NavMeshAgent Agent = null;
    [SerializeField] private Transform target;

    void Start()
    {
        //GetReference();
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
    private void GetReference()
    {
        Agent = GetComponent<NavMeshAgent>();
    }
}
