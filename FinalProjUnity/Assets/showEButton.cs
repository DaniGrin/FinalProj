using Project.Scrips;
using Project.Scrips.MessageDialog;
using Project.Scrips.SceneLoader;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class showEButton : MonoBehaviour
{
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
    void Update()
    {
        if (_isPlayerOnArea && Input.GetKey(KeyCode.E))
        {
            SceneLoaderManager.Instance.SwitchScene(SceneType.CutScene3);
        }
    }

}
