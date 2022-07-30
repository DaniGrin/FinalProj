using Project.Scrips.MessageDialog;
using UnityEngine;

namespace Project.Scrips.Weapon
{
    public class WeaponHolder : MonoBehaviour
    {
        [SerializeField] private Transform _weaponParent;
        [SerializeField] private Weapon _currentWeapon;
        private bool _isContainsWeapon;
        private bool _isPlayerNearWeapon;
        private Weapon _inAreaWeapon;

        private void SetWeapon(Weapon weapon)
        {
            if (_isContainsWeapon)
            {
                DestroyImmediate(_currentWeapon.gameObject);
            }

            _isContainsWeapon = true;
            _currentWeapon = weapon;
            _currentWeapon.transform.SetParent(_weaponParent);
        }
        
        private void Update()
        {
            if (_isPlayerNearWeapon && Input.GetKey(KeyCode.E) && _inAreaWeapon != _currentWeapon)
            {
                SetWeapon(_inAreaWeapon);
            }
        }
        
        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.CompareTag(ObjectsTag.Weapon))
            {
                MessageDialogManager.Instance.ShowEButton();
                _isPlayerNearWeapon = true;
                _inAreaWeapon = other.GetComponent<Weapon>();
            }
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.gameObject.CompareTag(ObjectsTag.Weapon))
            {
                MessageDialogManager.Instance.HideEButton();
                _isPlayerNearWeapon = false;
            }
        }
    }
}