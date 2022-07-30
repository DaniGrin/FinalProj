using System.Collections.Generic;
using UnityEngine;

namespace Project.Scrips.MessageDialog
{
    public class MessageDialogComponent : MonoBehaviour
    {
        [SerializeField] private string _id;
        [SerializeField] private string _title;
        [SerializeField] private Sprite _sprite;
        [SerializeField] private List<string> _messages;
        [SerializeField] private List<string> _repeatMessages;
        private const string _messageKey = "MessageUI-";
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
                Activate();
            }
        }

        private void Activate()
        {
            bool isAlreadyRead = PlayerPrefs.HasKey(GetFullKey());
            PlayerPrefs.SetInt(GetFullKey(), 1);

            var messageManager = MessageDialogManager.Instance;
            messageManager.SetMessages(_messages);
            messageManager.SetRepeatMessages(_repeatMessages);
            messageManager.SetTitle(_title);
            messageManager.SetSprite(_sprite);
            
            messageManager.ShowMessage(isAlreadyRead);
            messageManager.HideEButton();
        }

        private string GetFullKey()
        {
            return _messageKey + _id;
        }
    }
}