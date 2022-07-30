using UnityEngine;

namespace Project.Scrips.Weapon
{
    public class Weapon : MonoBehaviour
    {
        [SerializeField] private int _damage;

        public int GetDamage()
        {
            return _damage;
        }
    }
}