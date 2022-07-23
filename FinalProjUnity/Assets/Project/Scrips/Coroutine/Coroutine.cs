using System;
using System.Collections;
using UnityEngine;

namespace Project.Scrips.Coroutine
{
    public class Coroutine : ICoroutine
    {
        private readonly MonoBehaviour _monoBehaviour;
        private readonly Func<IEnumerator> _method;
        private UnityEngine.Coroutine _unityCoroutine;

        public Coroutine(MonoBehaviour monoBehaviour, Func<IEnumerator> method)
        {
            _monoBehaviour = monoBehaviour;
            _method = method;
        }

        public void Start()
        {
            if (_unityCoroutine != null)
            {
                Stop();
            }
            _unityCoroutine = _monoBehaviour.StartCoroutine(_method.Invoke());
        }

        public void Stop()
        {
            _monoBehaviour.StopCoroutine(_unityCoroutine);
            _unityCoroutine = null;
        }
    }
}