using System.Collections.Generic;
using UnityEngine;

namespace Project.Scrips.MessageDialog
{
    public interface IMessageDialogManager
    {
        bool IsActive();
        void SetTitle(string title);
        void SetSprite(Sprite sprite);
        void SetMessages(List<string>messages);
        void SetRepeatMessages(List<string>messages);

        void ShowMessage(bool isAlreadyRead);
        void ShowEButton();
        void HideEButton();
    }
}