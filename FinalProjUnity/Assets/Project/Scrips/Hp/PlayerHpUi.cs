using UnityEngine;
using UnityEngine.UI;

namespace Project.Scrips.Hp
{
    public class PlayerHpUi : MonoBehaviour
    {
        [SerializeField] private Text _hpText;
        [SerializeField] private HpEntityComponent _playerHp;

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
        }
    }
}