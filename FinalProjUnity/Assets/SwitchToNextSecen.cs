using Project.Scrips.SceneLoader;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchToNextSecen : MonoBehaviour
{
    private void OnEnable()
    {
        SceneLoaderManager.Instance.SwitchScene(SceneType.Hospital);
    }
}
