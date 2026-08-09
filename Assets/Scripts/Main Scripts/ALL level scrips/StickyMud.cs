using UnityEngine;

public class StickyMud : MonoBehaviour
{
    [Header("Speed Inside Mud")]
    public float mudSpeed = 1f;

    private void OnTriggerEnter2D(Collider2D other)
    {
        PlayerState state = other.GetComponent<PlayerState>();

        if (state != null)
        {
            state.currentSpeed = mudSpeed;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        PlayerState state = other.GetComponent<PlayerState>();

        if (state != null)
        {
            state.currentSpeed = state.baseSpeed;
        }
    }
}