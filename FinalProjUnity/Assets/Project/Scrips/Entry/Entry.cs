using Project.Scrips.SceneLoader;
using UnityEngine;
//script that attach to first scene to load the first scene in the game
namespace Project.Scrips.Entry
{
    public class Entry : MonoBehaviour
    {
        [SerializeField] private SceneType _sceneToLoadFirst;

        private void Start()
        {
            SceneLoaderManager.Instance.SwitchScene(_sceneToLoadFirst);
        }
    }
}