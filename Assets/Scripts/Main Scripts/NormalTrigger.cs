using UnityEngine;

public class NormalTrigger : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        MouseFollow player = other.GetComponent<MouseFollow>();

        if (player != null)
        {
            PlayerState state = other.GetComponent<PlayerState>();

            if (state != null)
            {
                state.reverseControls = false;
            }
        }
    }
}