using UnityEngine;

namespace Project.Scrips.Teleport
{
    public class TeleportPositionUpdater : MonoBehaviour
    {
        private void Awake()
        {
            if (PlayerConfig.Instance.ContainsStarterPosition)
            {
                transform.position = PlayerConfig.Instance.StarterPosition;
            }
        }
    }
}