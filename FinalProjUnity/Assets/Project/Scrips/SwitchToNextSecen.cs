using Project.Scrips.SceneLoader;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//this class is switch the scene to the next scene by the order of them
public class SwitchToNextSecen : MonoBehaviour
{
    [SerializeField] private SceneType _sceneType;

    private void OnEnable()
    {
        SceneLoaderManager.Instance.SwitchScene(_sceneType);
        
    }
}
