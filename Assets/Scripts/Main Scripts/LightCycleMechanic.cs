
using UnityEngine;
using UnityEngine.Rendering.Universal;
using System.Collections;

public class LightCycleMechanic : MonoBehaviour
{
    [Header("Global Light")]
    [SerializeField] private Light2D globalLight;

    [SerializeField] private float darkIntensity = 0f;
    [SerializeField] private float brightIntensity = 1f;

    [Header("Cycle Timing")]
    [SerializeField] private float interval = 5f;

    [Header("Player")]
    [SerializeField] private GameObject player;

    private Behaviour[] playerComponents;

    private SpriteRenderer[] playerSprites;

    private void Start()
    {
        if (globalLight == null || player == null)
        {
            Debug.LogError("Assign Global Light and Player in the Inspector!");
            enabled = false;
            return;
        }

        // Automatically collect the player's components.
        playerComponents = player.GetComponentsInChildren<Behaviour>(true);
        playerSprites = player.GetComponentsInChildren<SpriteRenderer>(true);

        // Start with darkness and player enabled.
        globalLight.intensity = darkIntensity;
        SetPlayerActive(true);

        StartCoroutine(LightCycle());
    }

    private IEnumerator LightCycle()
    {
        while (true)
        {
            // Wait before turning the light on.
            yield return new WaitForSeconds(interval);

            globalLight.intensity = brightIntensity;
            SetPlayerActive(false);

            // Wait before turning the light off.
            yield return new WaitForSeconds(interval);

            globalLight.intensity = darkIntensity;
            SetPlayerActive(true);
        }
    }

    private void SetPlayerActive(bool active)
    {
        // Toggle player visuals.
        foreach (SpriteRenderer sprite in playerSprites)
        {
            if (sprite != null)
                sprite.enabled = active;
        }

        // Toggle player behaviour scripts, excluding this mechanic.
        foreach (Behaviour component in playerComponents)
        {
            if (component != null && component != this)
                component.enabled = active;
        }
    }
}
