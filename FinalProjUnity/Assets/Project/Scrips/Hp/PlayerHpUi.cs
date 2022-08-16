using UnityEngine;
using UnityEngine.UI;

namespace Project.Scrips.Hp
{
    public class PlayerHpUi : MonoBehaviour
    {
        [SerializeField] private Text _hpText;
        [SerializeField] private HpEntityComponent _playerHp;
        [SerializeField] private GameObject _DeathMenu;

        private void OnEnable()
        {
            _playerHp.Updated += OnUpdated;
            UpdateHp();
        }

        private void OnDisable()
        {
            _playerHp.Updated -= OnUpdated;
        }

        private void OnUpdated()
        {
            UpdateHp();
        }

        private void UpdateHp()
        {
            _hpText.text = _playerHp.Value.ToString();
            if(int.Parse(_hpText.text) == 0 && _hpText.color == new Color(255, 0, 0, 255))
            {
                _DeathMenu.SetActive(true);
                Time.timeScale = 0f;
            }
            if (int.Parse(_hpText.text) > 55)
            {
                _hpText.color = new Color(0, 255, 0, 255);
            }
            if (int.Parse(_hpText.text) <= 55 && int.Parse(_hpText.text) > 20)
            {
                _hpText.color = new Color(255, 160, 0, 255);
            }
            if (int.Parse(_hpText.text) <= 20)
            {
                _hpText.color = new Color(255, 0, 0, 255);
            }
        }
    }
}