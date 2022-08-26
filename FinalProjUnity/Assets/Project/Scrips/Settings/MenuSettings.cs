using System;
using UnityEngine;
using UnityEngine.UI;
//this class display and update the game settings
public class MenuSettings : MonoBehaviour
{
    [SerializeField] private Slider _mouseSensitivity;
    [SerializeField] private Slider _volumeSlider;
    [SerializeField] private Dropdown _qualityDropdown;

    private void OnEnable()
    {
        _mouseSensitivity.onValueChanged.AddListener(OnMouseChanged);
        _volumeSlider.onValueChanged.AddListener(OnVolumeChanged);
        _qualityDropdown.onValueChanged.AddListener(OnQualityChanged);

        _mouseSensitivity.value = GameSettings.Instance.GetSensitivity();
        _volumeSlider.value = GameSettings.Instance.GetVolume();
        UpdateQuality(GameSettings.Instance.GetQuality());
    }

    private void OnQualityChanged(int arg0)
    {
        switch (_qualityDropdown.value)
        {
            case 0:
                GameSettings.Instance.SetQuality(GameQuality.low);
                break;
            case 1:
                GameSettings.Instance.SetQuality(GameQuality.medium);
                break;
            case 2:
                GameSettings.Instance.SetQuality(GameQuality.high);
                break;
            default:
                break;
        }
    }

    private void UpdateQuality(GameQuality gameQuality)
    {
        switch (gameQuality)
        {
            case GameQuality.low:
                _qualityDropdown.value = 0;
                break;
            case GameQuality.medium:
                _qualityDropdown.value = 1;

                break;
            case GameQuality.high:
                _qualityDropdown.value = 2;

                break;
            default:
                break;
        }
    }


    private void OnVolumeChanged(float volume)
    {
        GameSettings.Instance.SetVolume(volume);
    }

    private void OnMouseChanged(float value)
    {
        GameSettings.Instance.SetSensitivity(value);
    }
}
