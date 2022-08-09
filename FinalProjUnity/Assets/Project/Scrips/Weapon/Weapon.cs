using UnityEngine;

namespace Project.Scrips.Weapon
{
    public class Weapon : MonoBehaviour
    {
        [SerializeField] private int _damage;
        [SerializeField] private WeaponName _name;

        public WeaponName GetWeaponName()
        {
            return _name;
        }
        
        public int GetDamage()
        {
            return _damage;
        }
    }
}