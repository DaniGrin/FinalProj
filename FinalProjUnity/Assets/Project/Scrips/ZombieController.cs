using Project.Scrips;
using Project.Scrips.Hp;
using System;
using UnityEngine;
using UnityEngine.AI;

//this class allow to control the movement of the zombie its position , tracking the player  and activate its animations
public class ZombieController : MonoBehaviour
{
    private bool _isGrounded;
    private Vector3 _velocity;
    private float _zombieSpeed;

    [SerializeField] private Transform GroundCheck;
    [SerializeField] private float GroundDistance = 0.4f;
    [SerializeField] private LayerMask GroundMask;
    [SerializeField] private NavMeshAgent Agent = null;
    [SerializeField] private HpEntityComponent _zombieHp;
    [SerializeField] private ParticleSystem _particle;
    [SerializeField] private AudioSource _audio;
    private Transform _target;
    
    private Animator animator;
    private int isWalkHash;
    private int isAttackHash;
    private int isDeathHash;

    void Start()
    {
        animator = GetComponent<Animator>();
        isWalkHash = Animator.StringToHash("isWalking");
        isAttackHash = Animator.StringToHash("isAttacking");
        isDeathHash = Animator.StringToHash("isDeath");
        _zombieSpeed = Agent.speed;
        _target = GameObject.FindGameObjectWithTag(ObjectsTag.Player).transform;
        _zombieHp.Updated += OnUpdated;
    }
    private void OnDisable()
    {
        _zombieHp.Updated -= OnUpdated;
    }

    private void OnUpdated()
    {
        if (_zombieHp.Value <= 0)
        {
            animator.SetBool(isWalkHash, false);
            animator.SetBool(isAttackHash, false);
            animator.SetBool(isDeathHash, true);
        }
        _particle.Play(true);
        _audio.PlayDelayed(1);
        
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
        if (isZombieOnRange && distanceX <= 1.5 && distanceZ <= 1.5)
        {
            animator.SetBool(isWalkHash, false);
            animator.SetBool(isAttackHash, true);
        }
        else
        {
            animator.SetBool(isAttackHash, false);
        }
    }

    private void Stop()
    {
        animator.SetBool(isWalkHash, false);
        Agent.speed = 0;
    }

    private void MoveToTarget()
    {
        animator.SetBool(isWalkHash, true);
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
