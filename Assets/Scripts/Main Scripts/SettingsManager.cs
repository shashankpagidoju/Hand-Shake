using UnityEngine;
using UnityEngine.UI;

public class SettingsManager : MonoBehaviour
{
    public static SettingsManager Instance;

    [Header("Sliders")]
    public Slider volumeSlider;
    public Slider brightnessSlider;

    [Header("Brightness")]
    public Image brightnessOverlay;

    private float volume = 1f;
    private float brightness = 1f;

    private void Awake()
    {
        // Make SettingsManager global
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);

        // Load saved settings
        volume = PlayerPrefs.GetFloat("Volume", 1f);
        brightness = PlayerPrefs.GetFloat("Brightness", 1f);

        ApplyVolume(volume);
    }

    private void Start()
    {
        // Set sliders
        if (volumeSlider != null)
            volumeSlider.value = volume;

        if (brightnessSlider != null)
            brightnessSlider.value = brightness;

        ApplyBrightness(brightness);
    }

    public void SetVolume(float value)
    {
        volume = value;

        ApplyVolume(value);

        PlayerPrefs.SetFloat("Volume", value);
        PlayerPrefs.Save();

        Debug.Log("Volume: " + value);
    }

    public void SetBrightness(float value)
    {
        brightness = value;

        ApplyBrightness(value);

        PlayerPrefs.SetFloat("Brightness", value);
        PlayerPrefs.Save();

        Debug.Log("Brightness: " + value);
    }

    private void ApplyVolume(float value)
    {
        AudioListener.volume = value;

        Debug.Log("AudioListener Volume: " + AudioListener.volume);
    }

    private void ApplyBrightness(float value)
    {
        if (brightnessOverlay == null)
            return;

        Color color = brightnessOverlay.color;

        // 1 = normal
        // 0 = darkest
        color.a = 1f - value;

        brightnessOverlay.color = color;
    }
}