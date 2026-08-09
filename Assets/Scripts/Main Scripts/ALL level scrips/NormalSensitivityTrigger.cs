using UnityEngine;

public class NormalSensitivityTrigger : MonoBehaviour
{
    [Header("Player Speed After Leaving Machine")]
    public float normalSpeed = 15f;   // Change this in the Inspector

    private void OnTriggerEnter2D(Collider2D other)
    {
        PlayerState state = other.GetComponent<PlayerState>();

        if (state != null)
        {
            state.currentSpeed = normalSpeed;
        }
    }
}