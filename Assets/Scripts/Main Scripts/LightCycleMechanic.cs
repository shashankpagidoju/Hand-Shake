
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
    [SerializeField] private float darkWaitTime = 5f;
    [SerializeField] private float lightOnTime = 2f;

    [Header("Player / Ball")]
    [SerializeField] private GameObject player;

    [Header("Original / Back-Side Map")]
    [SerializeField] private GameObject originalMap;

    [Header("Random Maps")]
    [SerializeField] private GameObject[] maps;

    private Behaviour[] playerComponents;
    private SpriteRenderer[] playerSprites;

    private GameObject activeRandomMap;

    private void Start()
    {
        if (globalLight == null || player == null)
        {
            Debug.LogError("Assign Global Light and Player in the Inspector!");
            enabled = false;
            return;
        }

        playerComponents = player.GetComponentsInChildren<Behaviour>(true);
        playerSprites = player.GetComponentsInChildren<SpriteRenderer>(true);

        globalLight.intensity = darkIntensity;

        SetPlayerActive(true);

        if (originalMap != null)
            originalMap.SetActive(true);

        HideAllMaps();

        StartCoroutine(LightCycle());
    }

    private IEnumerator LightCycle()
    {
        while (true)
        {
            // Wait while the original map is visible.
            yield return new WaitForSeconds(darkWaitTime);

            // Turn Global Light ON.
            globalLight.intensity = brightIntensity;

            // Hide the original map.
            if (originalMap != null)
                originalMap.SetActive(false);

            // Disable the player and show a random map.
            SetPlayerActive(false);
            ShowRandomMap();

            yield return new WaitForSeconds(lightOnTime);

            // Turn Global Light OFF.
            globalLight.intensity = darkIntensity;

            // Hide the random map and restore the original.
            HideAllMaps();

            if (originalMap != null)
                originalMap.SetActive(true);

            SetPlayerActive(true);
        }
    }

    private void ShowRandomMap()
    {
        HideAllMaps();

        if (maps == null || maps.Length == 0)
        {
            Debug.LogWarning("No random maps assigned!");
            return;
        }

        int randomIndex = Random.Range(0, maps.Length);
        activeRandomMap = maps[randomIndex];

        if (activeRandomMap == null)
            return;

        activeRandomMap.SetActive(true);

        SpriteRenderer[] renderers =
            activeRandomMap.GetComponentsInChildren<SpriteRenderer>(true);

        foreach (SpriteRenderer sr in renderers)
        {
            if (sr != null)
                sr.sortingOrder = 100;
        }
    }

    private void HideAllMaps()
    {
        activeRandomMap = null;

        if (maps == null)
            return;

        foreach (GameObject map in maps)
        {
            if (map != null)
                map.SetActive(false);
        }
    }

    private void SetPlayerActive(bool active)
    {
        foreach (SpriteRenderer sprite in playerSprites)
        {
            if (sprite != null)
                sprite.enabled = active;
        }

        foreach (Behaviour component in playerComponents)
        {
            if (component != null && component != this)
                component.enabled = active;
        }
    }
}
