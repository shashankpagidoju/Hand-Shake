using UnityEngine;

public class ExitSoundManager : MonoBehaviour
{
    public static ExitSoundManager Instance;

    private AudioSource audioSource;

    void Awake()
    {
        // Prevent duplicates
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;

        DontDestroyOnLoad(gameObject);

        audioSource = GetComponent<AudioSource>();
    }

    public void PlayExitSound(AudioClip sound)
    {
        if (sound == null)
            return;

        audioSource.clip = sound;
        audioSource.loop = false;
        audioSource.Play();
    }
}