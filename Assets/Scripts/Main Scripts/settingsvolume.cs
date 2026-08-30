using UnityEngine;

public class settingsvolume : MonoBehaviour
{
    private AudioSource myaudioSource;

    private const string VolumeKey = "GameVolume";

    void Start()
    {
        myaudioSource = GetComponent<AudioSource>();

        // Get saved volume
        float savedVolume = PlayerPrefs.GetFloat(VolumeKey, 1f);

        myaudioSource.volume = savedVolume;
    }

    public void SetVolume(float volume)
    {
        // Change current audio
        myaudioSource.volume = volume;

        // Save volume for all scenes
        PlayerPrefs.SetFloat(VolumeKey, volume);
        PlayerPrefs.Save();
    }
}