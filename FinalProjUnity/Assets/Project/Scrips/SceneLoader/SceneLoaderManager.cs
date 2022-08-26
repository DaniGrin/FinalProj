using System;
using System.Collections;
using Project.Scrips.Coroutine;
using UnityEngine;
using UnityEngine.SceneManagement;
//this class load and enter to the scene 
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
        //function that load the next scene evrey frame and distroy the last scene
        private IEnumerator SwitchSceneAsync(SceneType scene)
        {
            if (!_isLoading)
            {
                _isLoading = true;
                //load the loading scene
                var loadingScene = SceneManager.LoadSceneAsync(GetNameScene(SceneType.Loading));
                //loop to wait for the scene to load and if its not load come back next frame
                while (!loadingScene.isDone)
                {
                    yield return null;
                }
                //wait 2 seconds for show the loader scene display
                yield return new WaitForSeconds(2);
                //load the next scene we want
                var toLoadScene = SceneManager.LoadSceneAsync(GetNameScene(scene), LoadSceneMode.Additive);
                //loop to wait for the scene to load and if its not load come back next frame
                while (!toLoadScene.isDone)
                {
                    yield return null;
                }
                //distroy last scene
                var unloadLoadingScene = SceneManager.UnloadSceneAsync(GetNameScene(SceneType.Loading));
                
                while (!unloadLoadingScene.isDone)
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
                case SceneType.Outside2:
                    name = "Scene_World2";
                    break;
                case SceneType.CutScene1:
                    name = "CutScene01";
                    break;
                case SceneType.CutScene2:
                    name = "CutScene02";
                    break;
                case SceneType.CutScene3:
                    name = "CutScene03";
                    break;
                case SceneType.CutScene4:
                    name = "CutScene04";
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(sceneType), sceneType, null);
            }

            return name;
        }
    }
}