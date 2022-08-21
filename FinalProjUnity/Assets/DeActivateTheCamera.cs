using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeActivateTheCamera : MonoBehaviour
{
    [SerializeField] private GameObject _camera;
    private void Start()
    {
        _camera.GetComponent<MouseLook>().enabled = false;
    }
}
