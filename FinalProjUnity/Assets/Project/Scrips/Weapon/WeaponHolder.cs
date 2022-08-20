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
        private string _weaponSaveKey = "WeaponSaveKey";

        public bool isHoldWeapon = false;


        private void Awake()
        {
            if(PlayerPrefs.HasKey(_weaponSaveKey))
            {
                WeaponName weaponName = (WeaponName)PlayerPrefs.GetInt(_weaponSaveKey);
                var foundWeapon = _playerWeapons.First(w => w.GetWeaponName() == weaponName);
                SetWeapon(foundWeapon);
            }

        }
        public bool ContainsWeapon()
        {
            return _isContainsWeapon;
        }

        public Weapon CurrentWeapon()
        {
            return _playerWeapons.First(w => w.GetWeaponName() == _currentWeapon);
        }

        private void SetWeapon(Weapon weapon)
        {
            if (_isContainsWeapon)
            {
                var currentWeapon = _playerWeapons.First(w => w.GetWeaponName() == _currentWeapon);
                currentWeapon.gameObject.SetActive(false);

                var dropped = Instantiate(currentWeapon.gameObject);
                dropped.gameObject.SetActive(true);
                dropped.transform.position = transform.position + new Vector3(0,2,0);
                dropped.AddComponent<Rigidbody>();
                _isContainsWeapon = false;
            }

            if (weapon == null)
            {
                PlayerPrefs.DeleteKey(_weaponSaveKey);
                return;
            }

            var weaponName = weapon.GetWeaponName();
            var foundWeapon = _playerWeapons.First(w => w.GetWeaponName() == weaponName);

            if (foundWeapon != weapon)
            {
                DestroyImmediate(weapon.gameObject);
            }

            foundWeapon.gameObject.SetActive(true);
            _currentWeapon = weaponName;
            _isContainsWeapon = true;
            
            MessageDialogManager.Instance.HideEButton();
            _isPlayerNearWeapon = false;
            PlayerPrefs.SetInt(_weaponSaveKey, (int)weaponName);
        }
        
        private void Update()
        {
            if (_isPlayerNearWeapon && Input.GetKeyDown(KeyCode.E))
            {
                SetWeapon(_inAreaWeapon);
                isHoldWeapon = true;
            }

            if (Input.GetKeyDown(KeyCode.G))
            {
                SetWeapon(null);
                isHoldWeapon = true;
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