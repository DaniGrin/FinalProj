using System.Collections.Generic;
using Project.Scrips.Hp;
using Project.Scrips.Weapon;
using UnityEngine;

//this class responsible on player & zombie healthPoints decrese while attacking
namespace Project.Scrips.Attack
{
    public class Attacker : MonoBehaviour
    {
        [SerializeField] private float _delayBetweenAttacksSeconds;
        [SerializeField] private WeaponHolder _weaponHolder;
        [SerializeField] private int _damageHands = 3;
        //only zombie auto attacking
        [SerializeField] private bool _isAttackAuto;
        [SerializeField] private HpEntityComponent _myHp;
        [SerializeField] private List<MonoBehaviour> _disallowScriptsOnDie;

        private float _lastAttack;
        private bool _containsEnemy;
        private HpEntityComponent _enemyHp;

        //decrease healthPoints to enemy( if this player it will decrease to zombie else it will decrease to player)
        private void Update()
        {
            bool isPlayerClick = Input.GetKeyDown(KeyCode.Mouse0);
            if ((!_isAttackAuto && isPlayerClick || _isAttackAuto) && Time.time - _lastAttack >= _delayBetweenAttacksSeconds)
            {
                _lastAttack = Time.time;

                int damage;
                if (_weaponHolder == null || !_weaponHolder.ContainsWeapon())
                {
                    damage = _damageHands;
                }
                else
                {
                    damage = _weaponHolder.CurrentWeapon().GetDamage();
                }

                if (_containsEnemy && ((!_enemyHp.isZombie() && _isAttackAuto) || (_enemyHp.isZombie() && isPlayerClick)))
                {
                    _enemyHp.Decrease(damage);
                }
            }
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent(out HpEntityComponent hpEntityComponent) && _myHp != hpEntityComponent)
            {
                _enemyHp = hpEntityComponent;
                _containsEnemy = true;
            }
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.TryGetComponent(out HpEntityComponent hpEntityComponent) && _myHp != hpEntityComponent)
            {
                _containsEnemy = false;
            }
        }

        private void OnEnable()
        {
            _myHp.Updated += OnHpUpdated;
        }

        private void OnDisable()
        {
            _myHp.Updated -= OnHpUpdated;
        }

        private void OnHpUpdated()
        {
            if (_myHp.Value <= 0)
            {
                foreach (var monoBehaviour in _disallowScriptsOnDie)
                {
                    monoBehaviour.enabled = false;
                }
            }
        }
    }
}