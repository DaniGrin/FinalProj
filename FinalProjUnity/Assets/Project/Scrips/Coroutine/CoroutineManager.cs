using System.Collections;
using UnityEngine;
//this class allow to load the scenes
namespace Project.Scrips.Coroutine
{
    public class CoroutineManager : MonoBehaviour
    {
        private static CoroutineManager _coroutineManager;

        public static CoroutineManager Instance
        {
            get
            {
                if (_coroutineManager == null)
                {
                    var gameObject = new GameObject("CoroutineManager");
                    gameObject.AddComponent(typeof(CoroutineManager));
                    _coroutineManager = gameObject.GetComponent<CoroutineManager>();
                    DontDestroyOnLoad(gameObject);
                }

                return _coroutineManager;
            }
        }

        public void StartAsyncMethod(IEnumerator method)
        {
            _coroutineManager.StartCoroutine(method);
        }
    }
}