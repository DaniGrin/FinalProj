using UnityEngine;
using UnityEngine.UI;

public class MenuSettings : MonoBehaviour
{
    [SerializeField] private Slider _mouseSensitivity;

    private void OnEnable()
    {
        _mouseSensitivity.onValueChanged.AddListener(OnMouseChanged);
    }

    private void OnMouseChanged(float value)
    {
        GameSettings.ChangeMouse(value);
    }
}
