using Project.Scrips.SceneLoader;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public void LoadGameButton()
    {
        SceneLoaderManager.Instance.SwitchScene(SceneType.Hospital);
    }

    public void ExitButton()
    {
        Application.Quit();
    }

    public void StartGame()
    {
        PlayerPrefs.DeleteAll();
        SceneLoaderManager.Instance.SwitchScene(SceneType.Hospital);
    }
}
