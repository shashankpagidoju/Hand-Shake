using UnityEngine;

public class MagnetPull : MonoBehaviour
{
    [Header("Magnet Settings")]
    public float magnetStrength = 3f;

    private MouseFollow player;
    private PlayerState state;

    private void OnTriggerEnter2D(Collider2D other)
    {
        PlayerState foundState = other.GetComponent<PlayerState>();

        if (foundState != null)
        {
            state = foundState;
            player = other.GetComponent<MouseFollow>();
        }
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (player == null || state == null)
            return;

        Vector2 direction =
            ((Vector2)transform.position - (Vector2)player.transform.position).normalized;

        Vector2 pull =
            direction * magnetStrength * Time.fixedDeltaTime;

        player.transform.position += (Vector3)pull;
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.GetComponent<PlayerState>() != null)
        {
            player = null;
            state = null;
        }
    }
}