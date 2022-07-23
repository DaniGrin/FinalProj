using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Project.Scrips.MessageDialog
{
    public class MessageDialogManager : MonoBehaviour, IMessageDialogManager
    {
        [SerializeField] private Text _title;
        [SerializeField] private Text _message;
        [SerializeField] private Image _image;
        [SerializeField] private GameObject _ui;
        [SerializeField] private GameObject _eButton;

        private List<string> _messages;
        private List<string> _repeatMessages;
        private bool _isRepeat;
        private int _messageIndex;
        private static IMessageDialogManager _instance;

        public bool IsActive()
        {
            return _ui.activeInHierarchy;
        }

        private void Awake()
        {
            if (_instance == null)
            {
                _instance = this;
                DontDestroyOnLoad(gameObject);
            }
            else
            {
                Destroy(gameObject);
            }
        }

        public static IMessageDialogManager Instance => _instance;

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space) && _ui.activeInHierarchy)
            {
                NextMessage();
            }
        }

        public void SetTitle(string title)
        {
            _title.text = title;
        }

        public void SetSprite(Sprite sprite)
        {
            _image.sprite = sprite;
            _image.enabled = sprite != null;
        }

        public void SetMessages(List<string> messages)
        {
            _messages = messages;
        }

        public void SetRepeatMessages(List<string> messages)
        {
            _repeatMessages = messages;
        }

        public void ShowMessage(bool isAlreadyRead)
        {
            _messageIndex = -1;

            var isMessagesValid = isAlreadyRead && _repeatMessages != null && _repeatMessages.Count > 0 ||
                                  !isAlreadyRead && _messages != null && _messages.Count > 0;

            if (isMessagesValid)
            {
                _ui.SetActive(true);
                NextMessage();
            }
        }

        public void ShowEButton()
        {
            _eButton.SetActive(true);
        }

        public void HideEButton()
        {
            _eButton.SetActive(false);
        }

        private void NextMessage()
        {
            ++_messageIndex;
            bool canNext;
            string message = "";

            if (_isRepeat)
            {
                canNext = _repeatMessages.Count > _messageIndex;
                if (canNext)
                {
                    message = _repeatMessages[_messageIndex];
                }
                else
                {
                    Hide();
                }
            }
            else
            {
                canNext = _messages.Count > _messageIndex;
                if (canNext)
                {
                    message = _messages[_messageIndex];
                }
                else
                {
                    _isRepeat = true;
                    Hide();
                }
            }

            _message.text = message;
        }

        private void Hide()
        {
            _ui.SetActive(false);
        }
    }
}