using UnityEngine;

public class HighSpeedTrigger : MonoBehaviour
{
    public float speedMultiplier = 2f;

    private void OnTriggerEnter2D(Collider2D other)
    {
        PlayerState state = other.GetComponent<PlayerState>();

        if (state != null)
        {
            state.currentSpeed = state.baseSpeed * speedMultiplier;
        }
    }
}