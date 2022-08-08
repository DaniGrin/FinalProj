using Project.Scrips;
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
    private Transform _target;

    void Start()
    {
        _zombieSpeed = Agent.speed;
        _target = GameObject.FindGameObjectWithTag(ObjectsTag.Player).transform;
    }

    void Update()
    {
        _isGrounded = Physics.CheckSphere(GroundCheck.position, GroundDistance, GroundMask);

        if (_isGrounded && _velocity.y < 0)
        {
            _velocity.y = -2f;
        }

        float distanceX = Mathf.Abs(transform.position.x - _target.position.x);
        float distanceZ = Mathf.Abs(transform.position.z - _target.position.z);

        bool isZombieOnRange = distanceX <= 12 && distanceX > 0 && distanceZ <= 12 && distanceZ >0;
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
        Agent.SetDestination(_target.position);
        RotateToTarget();
        Agent.speed = _zombieSpeed;

    }
    private void RotateToTarget()
    {
        var targetPosition = _target.position;
        targetPosition.y = transform.position.y;
        transform.LookAt(targetPosition);
        
        //Vector3 direction = target.position - transform.position;
        //Quaternion rotation = Quaternion.LookRotation(direction, Vector3.up);
        //transform.rotation = rotation;
    }
    
}
