using UnityEngine;
using UnityEngine.UI;

public class FullscreenToggle : MonoBehaviour
{
    public Toggle fullscreenToggle;

    private void Start()
    {
        // Add listener to the toggle's onValueChanged event
        fullscreenToggle.onValueChanged.AddListener(OnToggleValueChanged);
    }

    private void OnToggleValueChanged(bool newValue)
    {
        // Toggle fullscreen/windowed mode based on the toggle's value
        Screen.fullScreen = newValue;
    }
}
