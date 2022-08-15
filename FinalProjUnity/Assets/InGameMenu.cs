using Project.Scrips.SceneLoader;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InGameMenu : MonoBehaviour
{
    [SerializeField] GameObject _inGameMenu;
    [SerializeField] GameObject _camera;

    public static bool GameIsPaused = false;

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if(GameIsPaused)
            {
                ReturnToGame();
            }
            else
            {
                Paused();
            }
        }
    }

    private void Paused()
    {
        _inGameMenu.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
        _camera.GetComponent<MouseLook>().enabled = false;
    }

    public void ReturnToGame()
    {
        _inGameMenu.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
        _camera.GetComponent<MouseLook>().enabled = true;
    }

    public void ReturntoMenu()
    {
        Time.timeScale = 1f;
        SceneLoaderManager.Instance.SwitchScene(SceneType.Menu);
    }
}
