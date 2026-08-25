using UnityEngine;

public class settingsvolume : MonoBehaviour
{
    AudioSource myaudioSource;

    float musicVolume = 1f;
    void Start()
    {
        myaudioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        myaudioSource.volume = musicVolume;
    }

    public void SetVolume(float volume)
    {
        musicVolume = volume;
    }
}

