using System.Collections;
using Project.Scrips.Coroutine;
using UnityEngine;

namespace Project.Scrips.Teleport
{
    public class TeleportPositionUpdater : MonoBehaviour
    {
        private void Awake()
        {
            if (PlayerConfig.Instance.ContainsStarterPosition)
            {
                CoroutineManager.Instance.StartAsyncMethod(UpdatePosition());
            }
        }

        private IEnumerator UpdatePosition()
        {
            int leftFrameToUpdate = 10;

            while (leftFrameToUpdate > 0)
            {
                leftFrameToUpdate--;
                yield return null;
            }

            transform.position = PlayerConfig.Instance.StarterPosition;
        }
    }
}