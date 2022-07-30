using Project.Scrips.MessageDialog;
using Project.Scrips.SceneLoader;
using UnityEngine;

namespace Project.Scrips.Teleport
{
    public class Teleport : MonoBehaviour
    {
        [SerializeField] private SceneType _scene;
        [SerializeField] private Vector3 _playerPosition;
        private bool _isPlayerOnArea;

        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.CompareTag(ObjectsTag.Player))
            {
                MessageDialogManager.Instance.ShowEButton();
                _isPlayerOnArea = true;
            }
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.gameObject.CompareTag(ObjectsTag.Player))
            {
                MessageDialogManager.Instance.HideEButton();
                _isPlayerOnArea = false;
            }
        }
        
        private void Update()
        {
            if (_isPlayerOnArea && Input.GetKey(KeyCode.E))
            {
                PlayerConfig.Instance.StarterPosition = _playerPosition;
                PlayerConfig.Instance.CurrentPlayerScene = _scene;
                SceneLoaderManager.Instance.SwitchScene(_scene);
            }
        }
    }
}