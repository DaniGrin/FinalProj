using Project.Scrips.SceneLoader;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// this class allow to open a menu inside the game by pressing ESC button
// also its switches scene if the player choose to go back to the main screen of the game 
public class InGameMenu : MonoBehaviour
{
    [SerializeField] private GameObject _inGameMenu;
    [SerializeField] private GameObject _camera;

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
