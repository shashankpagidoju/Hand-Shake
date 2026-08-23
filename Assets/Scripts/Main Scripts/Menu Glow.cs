using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class MenuGlow : MonoBehaviour
{
    [Header("Volume")]
    public Volume globalVolume;

    [Header("Glow Settings")]
    [Range(0f, 1f)]
    public float maxScatter = 0.9f;

    [Tooltip("Time taken to go from 0 to max and max back to 0")]
    public float glowDuration = 3f;

    private Bloom bloom;
    private float timer;

    void Start()
    {
        if (globalVolume == null)
        {
            Debug.LogError("Global Volume is not assigned!");
            return;
        }

        if (globalVolume.profile.TryGet(out bloom))
        {
            bloom.scatter.value = 0f;
        }
        else
        {
            Debug.LogError("Bloom override not found!");
        }
    }

    void Update()
    {
        if (bloom == null)
            return;

        timer += Time.deltaTime;

        float value = Mathf.PingPong(timer / glowDuration, 1f);

        bloom.scatter.value = value * maxScatter;
    }
}