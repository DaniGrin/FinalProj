using Project.Scrips.SceneLoader;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchToFinalScene : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        SceneLoaderManager.Instance.SwitchScene(SceneType.CutScene4);
    }
}
