using UnityEngine;

namespace Project.Scrips.Teleport
{
    public class TeleportPositionUpdater : MonoBehaviour
    {
        [SerializeField] private Transform _playerTransform;
        private bool _isPositionSet;

        private void FixedUpdate()
        {
            if (!_isPositionSet && PlayerConfig.Instance.ContainsStarterPosition)
            {
                _playerTransform.position = PlayerConfig.Instance.StarterPosition;
                _isPositionSet = true;
            }
        }
    }
}