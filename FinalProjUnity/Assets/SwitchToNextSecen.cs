using Project.Scrips.SceneLoader;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchToNextSecen : MonoBehaviour
{
    [SerializeField] private SceneType _sceneType;

    private void OnEnable()
    {
        SceneLoaderManager.Instance.SwitchScene(_sceneType);
        
    }
}
