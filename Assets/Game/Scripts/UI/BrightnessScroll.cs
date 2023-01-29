using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Rendering.PostProcessing;

public class BrightnessScroll : MonoBehaviour
{
    [SerializeField] private Slider brightSlider;
    [SerializeField] private PostProcessLayer layer;
    [SerializeField] private PostProcessProfile brightness;

    private AutoExposure exposure;
    void Start()
    {
        brightness.TryGetSettings(out exposure);
        AdjustBrightness(brightSlider.value);
    }
    public void AdjustBrightness(float value) 
    {
        if(value != 0) 
        {
            exposure.keyValue.value = value;
        }
        else 
        {
            exposure.keyValue.value = 0f;
        }
    }
    
}
