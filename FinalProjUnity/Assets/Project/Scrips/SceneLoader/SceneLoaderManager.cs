using System;
using System.Collections;
using Project.Scrips.Coroutine;
using UnityEngine.SceneManagement;

namespace Project.Scrips.SceneLoader
{
    public class SceneLoaderManager : ISceneLoaderManager
    {
        private static SceneLoaderManager _instance;
        private bool _isLoading;

        public static ISceneLoaderManager Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new SceneLoaderManager();
                }

                return _instance;
            }
        }

        public void SwitchScene(SceneType scene)
        {
            CoroutineManager.Instance.StartAsyncMethod(SwitchSceneAsync(scene));
        }

        private IEnumerator SwitchSceneAsync(SceneType scene)
        {
            if (!_isLoading)
            {
                _isLoading = true;

                var loadingScene = SceneManager.LoadSceneAsync(GetNameScene(SceneType.Loading));

                while (!loadingScene.isDone)
                {
                    yield return null;
                }

                var toLoadScene = SceneManager.LoadSceneAsync(GetNameScene(scene));

                while (!toLoadScene.isDone)
                {
                    yield return null;
                }
                
                _isLoading = false;
            }
        }

        private string GetNameScene(SceneType sceneType)
        {
            string name;
        
            switch (sceneType)
            {
                case SceneType.Entry:
                    name = "EntryScene";
                    break;
                case SceneType.Loading:
                    name = "Loading";
                    break;
                case SceneType.Menu:
                    name = "UIMenu";
                    break;
                case SceneType.Hospital:
                    name = "Hospital";
                    break;
                case SceneType.Police:
                    name = "PoliceScene";
                    break;
                case SceneType.Outside:
                    name = "SCENE_Apocalyptic_World_Assets";
                    break;
                case SceneType.CutScene1:
                    name = "CutScene";
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(sceneType), sceneType, null);
            }

            return name;
        }
    }
}