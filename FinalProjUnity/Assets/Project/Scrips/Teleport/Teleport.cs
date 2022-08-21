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

        public bool isCutScene;

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

        private void Awake()
        {
            if(isCutScene == true)
            {
                _isPlayerInTeleportArea = false;
                PlayerConfig.Instance.StarterPosition = _playerPositionInNewScene;
                PlayerConfig.Instance.CurrentPlayerScene = _sceneToMove;
                SceneLoaderManager.Instance.SwitchScene(_sceneToMove);
                isCutScene = false;
            }
        }

        private void Update()
        {
            if (_isPlayerInTeleportArea && Input.GetKey(KeyCode.E))
            {
                MessageDialogManager.Instance.HideEButton();
                _isPlayerInTeleportArea = false;
                PlayerConfig.Instance.StarterPosition = _playerPositionInNewScene;
                PlayerConfig.Instance.CurrentPlayerScene = _sceneToMove;
                SceneLoaderManager.Instance.SwitchScene(_sceneToMove);
            }
        }

    }
}