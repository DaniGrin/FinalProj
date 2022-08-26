using Project.Scrips.SceneLoader;
using UnityEngine;
//this class allow us to save the player position on the map and the scene that he last teleport to
namespace Project.Scrips.Teleport
{
    public class PlayerConfig
    {
        private static PlayerConfig _instance;
        private const string _savePositionKey = "player-position-";
        private const string _saveSceneKey = "player-scene";

        public static PlayerConfig Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new PlayerConfig();
                }

                return _instance;
            }
        }

        public bool ContainsStarterPosition => PlayerPrefs.HasKey(_savePositionKey + "x");
        
        public Vector3 StarterPosition
        {
            get
            {
                Vector3 position = new Vector3(
                    PlayerPrefs.GetFloat(_savePositionKey+"x", 0),
                    PlayerPrefs.GetFloat(_savePositionKey+"y", 0),
                    PlayerPrefs.GetFloat(_savePositionKey+"z", 0)
                );

                return position;
            }
            set
            {
                PlayerPrefs.SetFloat(_savePositionKey+"x", value.x);
                PlayerPrefs.SetFloat(_savePositionKey+"y", value.y);
                PlayerPrefs.SetFloat(_savePositionKey+"z", value.z);

                PlayerPrefs.Save();
            }
        }

        public bool ContainsCurrentPlayerScene => PlayerPrefs.HasKey(_saveSceneKey);

        public SceneType CurrentPlayerScene
        {
            get
            {
                return (SceneType)PlayerPrefs.GetInt(_saveSceneKey, 0);
            }
            set
            {
                PlayerPrefs.SetInt(_saveSceneKey, (int)value);
                PlayerPrefs.Save();
            }
        }
    }
}