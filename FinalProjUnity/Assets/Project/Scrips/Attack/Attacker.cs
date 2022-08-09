using Project.Scrips.Hp;
using Project.Scrips.Weapon;
using UnityEngine;

namespace Project.Scrips.Attack
{
    public class Attacker : MonoBehaviour
    {
        [SerializeField] private float _delayBetweenAttacksSeconds;
        [SerializeField] private WeaponHolder _weaponHolder;
        [SerializeField] private int _damageHands = 3;
        [SerializeField] private bool _isAttackAuto;
        [SerializeField] private HpEntityComponent _myHp;

        private float _lastAttack;
        private bool _containsEnemy;
        private HpEntityComponent _enemyHp;

        private void Update()
        {
            if ((!_isAttackAuto && Input.GetKeyDown(KeyCode.T) || _isAttackAuto) && Time.time - _lastAttack >= _delayBetweenAttacksSeconds)
            {
                _lastAttack = Time.time;

                int damage;
                if (_weaponHolder == null || !_weaponHolder.ContainsWeapon())
                {
                    damage = _damageHands;
                    // TODO: activate hands attack animation
                }
                else
                {
                    damage = _weaponHolder.CurrentWeapon().GetDamage();
                    // TODO: activate weapon attack animation
                }

                if (_containsEnemy)
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
    }
}