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
        bool isZombieOnRange = transform.position.x - _target.position.x <= 12 && transform.position.x - _target.position.x > 0 || _target.position.x - transform.position.x <= 12 && _target.position.x - transform.position.x > 0;
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
