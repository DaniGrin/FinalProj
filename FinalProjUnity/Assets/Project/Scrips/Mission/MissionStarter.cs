using Project.Scrips;
using Project.Scrips.MessageDialog;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//this class summons zombies around a game object while player press a button as a trigger 
public class MissionStarter : MonoBehaviour
{
    private bool _isPlayerOnArea;
    [SerializeField] private GameObject _zombie;
    [SerializeField] private GameObject _alert;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag(ObjectsTag.Player) && !PlayerPrefs.HasKey(GetFullKey()))
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
            Activate();
        }
    }

    private void Activate()
    {
        PlayerPrefs.SetInt(GetFullKey(), 1);
        _zombie.SetActive(true);
        _alert.SetActive(true);
    }
    //get the id for the PlayerPrefs
    private string GetFullKey()
    {
        return "taskZombieAlert";
    }
}
