using UnityEngine;
using UnityEngine.UI;

public class SpeedControl : MonoBehaviour
{
    [SerializeField] private Slider speedSlider; // Reference to the slider

    void Start()
    {
        // Set the default slider value to match the initial cube speed
        speedSlider.value = 2f;
        speedSlider.onValueChanged.AddListener(OnSliderValueChanged);
    }

    private void OnSliderValueChanged(float value)
    {
        // Update the speed of all cubes using the slider value
        Movement.UpdateGlobalSpeed(value);
    }
}
