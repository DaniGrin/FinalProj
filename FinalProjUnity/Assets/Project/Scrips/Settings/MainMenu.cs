using Project.Scrips.SceneLoader;
using Project.Scrips.Teleport;
using UnityEngine;
//this class is allow to use the menu buttons(Start,LoadGame,Exit)
public class MainMenu : MonoBehaviour
{
    public void LoadGameButton()
    {
        if (PlayerConfig.Instance.ContainsCurrentPlayerScene)
        {
            SceneLoaderManager.Instance.SwitchScene(PlayerConfig.Instance.CurrentPlayerScene);
        }
        else
        {
            StartGame();
        }
    }

    public void ExitButton()
    {
        Application.Quit();
    }

    public void StartGame()
    {
        PlayerPrefs.DeleteAll();
        SceneLoaderManager.Instance.SwitchScene(SceneType.CutScene1);
    }
}
