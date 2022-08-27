using Project.Scrips.SceneLoader;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//this class is activate the last cutScene of the game
public class SwitchToFinalScene : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        SceneLoaderManager.Instance.SwitchScene(SceneType.CutScene4);
    }
}
