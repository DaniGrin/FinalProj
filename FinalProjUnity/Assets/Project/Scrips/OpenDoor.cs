using Project.Scrips;
using Project.Scrips.MessageDialog;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenDoor : MonoBehaviour
{
    [SerializeField] private Animator _animator;
    bool isPlayerNearDoor;
    private void OnTriggerEnter(Collider other)
    {
        
        if (other.gameObject.CompareTag(ObjectsTag.Player))
        {
            MessageDialogManager.Instance.ShowEButton();
            isPlayerNearDoor = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag(ObjectsTag.Player))
        {
            MessageDialogManager.Instance.HideEButton();
            isPlayerNearDoor = false;
        }
    }
    // Update is called once per frame
    void Update()
    {
        if (isPlayerNearDoor && Input.GetKey(KeyCode.E))
        {
            _animator.Play("Opening");
        }


    }
    
}
