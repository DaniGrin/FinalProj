using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//this methods display and update the settings
public interface IGameSettings
{
    float GetSensitivity();
    float GetVolume();
    GameQuality GetQuality();

    void SetVolume(float volume);
    void SetSensitivity(float volume);
    void SetQuality(GameQuality quality);
    
}
