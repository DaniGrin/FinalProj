using Project.Scrips.MessageDialog;
using Project.Scrips.SceneLoader;
using UnityEngine;

namespace Project.Scrips.Teleport
{
    public class Teleport : MonoBehaviour
    {
        [SerializeField] private SceneType _sceneToMove;
        [SerializeField] private Vector3 _playerPositionInNewScene;
        private bool _isPlayerInTeleportArea;

        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.CompareTag(ObjectsTag.Player))
            {
                MessageDialogManager.Instance.ShowEButton();
                _isPlayerInTeleportArea = true;
            }
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.gameObject.CompareTag(ObjectsTag.Player))
            {
                MessageDialogManager.Instance.HideEButton();
                _isPlayerInTeleportArea = false;
            }
        }
        
        private void Update()
        {
            if (_isPlayerInTeleportArea && Input.GetKey(KeyCode.E))
            {
                PlayerConfig.Instance.StarterPosition = _playerPositionInNewScene;
                PlayerConfig.Instance.CurrentPlayerScene = _sceneToMove;
                SceneLoaderManager.Instance.SwitchScene(_sceneToMove);
            }
        }
    }
}