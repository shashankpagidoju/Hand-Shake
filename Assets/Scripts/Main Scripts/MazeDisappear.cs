using System.Collections;
using UnityEngine;

public class MazeDisappear : MonoBehaviour
{
    [Header("Walls")]
    public Transform walls;

    [Header("Settings")]
    public float disappearTime = 5f;

    private SpriteRenderer[] wallSprites;

    private void Awake()
    {
        wallSprites = walls.GetComponentsInChildren<SpriteRenderer>(true);
    }

    public void DisappearFor5Seconds()
    {
        StartCoroutine(DisappearRoutine());
    }

    private IEnumerator DisappearRoutine()
    {
        // Turn OFF only SpriteRenderers
        foreach (SpriteRenderer sprite in wallSprites)
        {
            sprite.enabled = false;
        }

        Debug.Log("Walls disappeared");

        // Wait 5 seconds
        yield return new WaitForSeconds(disappearTime);

        // Turn ON SpriteRenderers
        foreach (SpriteRenderer sprite in wallSprites)
        {
            sprite.enabled = true;
        }

        Debug.Log("Walls appeared");
    }
}