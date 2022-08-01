using Project.Scrips.SceneLoader;
using UnityEngine;

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