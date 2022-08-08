using System.Collections.Generic;
using System.Linq;
using Project.Scrips.MessageDialog;
using Unity.VisualScripting;
using UnityEngine;

namespace Project.Scrips.Weapon
{
    public class WeaponHolder : MonoBehaviour
    {
        [SerializeField] private List<Weapon> _playerWeapons;
        
        private bool _isContainsWeapon;
        private bool _isPlayerNearWeapon;
        private Weapon _inAreaWeapon;
        private WeaponName _currentWeapon;

        private void SetWeapon(Weapon weapon)
        {
            var weaponName = weapon.GetWeaponName();
            DestroyImmediate(weapon.gameObject);
            
            if (_isContainsWeapon)
            {
                var currentWeapon = _playerWeapons.First(w => w.GetWeaponName() == _currentWeapon);
                currentWeapon.gameObject.SetActive(false);

                var dropped = Instantiate(currentWeapon.gameObject);
                dropped.gameObject.SetActive(true);
                dropped.transform.position = transform.position;
                dropped.AddComponent<Rigidbody>();
            }
            
            _playerWeapons.First(w => w.GetWeaponName() == weaponName).gameObject.SetActive(true);
            _currentWeapon = weaponName;
            _isContainsWeapon = true;
            
            MessageDialogManager.Instance.HideEButton();
            _isPlayerNearWeapon = false;
        }
        
        private void Update()
        {
            if (_isPlayerNearWeapon && Input.GetKey(KeyCode.E))
            {
                SetWeapon(_inAreaWeapon);
            }
        }
        
        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.CompareTag(ObjectsTag.Weapon))
            {
                var weapon = other.GetComponent<Weapon>();
                
                if (_isContainsWeapon && weapon.GetWeaponName() == _currentWeapon)
                {
                    return;
                }
                
                MessageDialogManager.Instance.ShowEButton();
                _isPlayerNearWeapon = true;
                _inAreaWeapon = other.GetComponent<Weapon>();
            }
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.gameObject.CompareTag(ObjectsTag.Weapon))
            {
                var weapon = other.GetComponent<Weapon>();

                if (_isContainsWeapon && weapon.GetWeaponName() == _currentWeapon)
                {
                    return;
                }
                
                MessageDialogManager.Instance.HideEButton();
                _isPlayerNearWeapon = false;
            }
        }
    }
}