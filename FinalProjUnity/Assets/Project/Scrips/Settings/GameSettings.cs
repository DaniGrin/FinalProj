using UnityEngine;
//this class allows to change the game settings in the system
public class GameSettings : IGameSettings
{
    private static GameSettings _instance;
    private string _mouseSaveKey = "mouseSettings";
    private string _volumeSaveKey = "volumeSettings";
    private string _qualitySaveKey = "qualitySettings";

    public static IGameSettings Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = new GameSettings();
            }

            return _instance;
        }
    }

    private GameSettings()
    {
        SetQuality(GetQuality());
        SetVolume(GetVolume());
        SetSensitivity(GetSensitivity());
    }

    public GameQuality GetQuality()
    {
        return (GameQuality)PlayerPrefs.GetInt(_qualitySaveKey, 0);
    }

    public float GetSensitivity()
    {
        return PlayerPrefs.GetFloat(_mouseSaveKey, 100f);
    }

    public float GetVolume()
    {
        return PlayerPrefs.GetFloat(_volumeSaveKey, 100f);
    }

    public void SetQuality(GameQuality quality)
    {
        PlayerPrefs.SetInt(_qualitySaveKey, (int)quality);

        switch (quality)
        {
            case GameQuality.low:
                QualitySettings.SetQualityLevel(0, true);
                break;
            case GameQuality.medium:
                QualitySettings.SetQualityLevel(2, true);
                break;
            case GameQuality.high:
                QualitySettings.SetQualityLevel(5, true);
                break;
            default:
                break;
        }
        
    }

    public void SetSensitivity(float sensitivity)
    {
        PlayerPrefs.SetFloat(_mouseSaveKey, sensitivity);
    }

    public void SetVolume(float volume)
    {
        AudioListener.volume = volume;
        PlayerPrefs.SetFloat(_volumeSaveKey, volume);
    }
}
