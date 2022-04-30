using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ZombieController : MonoBehaviour
{
    public NavMeshAgent agent = null;
    [SerializeField] private Transform target;

    void Start()
    {
        //GetReference();
    }

    void Update()
    {
        MoveToTarget();
    }
    private void MoveToTarget()
    {
        agent.SetDestination(target.position);

        RotateToTarget();
        
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
