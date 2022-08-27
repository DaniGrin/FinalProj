using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//this class moves the camera view by the mouse movement 
public class DeActivateTheCamera : MonoBehaviour
{
    [SerializeField] private GameObject _camera;
    private void Start()
    {
        _camera.GetComponent<MouseLook>().enabled = false;
    }
    private void OnDisable()
    {
        _camera.GetComponent<MouseLook>().enabled = true;
    }
}
