using UnityEngine;

public class ExitAudio : MonoBehaviour
{
    public AudioClip exitSound;

    private bool triggered = false;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (triggered)
            return;

        if (other.GetComponent<PlayerState>() != null)
        {
            triggered = true;

            if (ExitSoundManager.Instance != null)
            {
                ExitSoundManager.Instance.PlayExitSound(exitSound);
            }
        }
    }
}