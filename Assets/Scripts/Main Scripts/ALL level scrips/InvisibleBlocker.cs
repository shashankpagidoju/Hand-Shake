using UnityEngine;

public class InvisibleBlocker : MonoBehaviour
{
    private MouseFollow mouseFollow;
    private PlayerState playerState;
    private Rigidbody2D rb;

    private Vector2 safePosition;
    private bool inside = false;

    private void OnTriggerEnter2D(Collider2D other)
    {
        playerState = other.GetComponent<PlayerState>();

        if (playerState == null)
            return;

        mouseFollow = other.GetComponent<MouseFollow>();
        rb = other.GetComponent<Rigidbody2D>();

        if (rb != null)
            safePosition = rb.position;

        inside = true;
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (!inside || rb == null)
            return;

        if (other.GetComponent<PlayerState>() == null)
            return;

        // Keep the player at the safe side of the blocker
        rb.position = safePosition;
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.GetComponent<PlayerState>() == null)
            return;

        inside = false;
    }
}