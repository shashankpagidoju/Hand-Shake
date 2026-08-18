using UnityEngine;

public class Death : MonoBehaviour
{
    public GameManager gameManager;
    public GameObject ballBreakEffect;

    private bool hasDied = false;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (hasDied)
            return;

        if (other.CompareTag("Death"))
        {
            hasDied = true;

            // Spawn shatter effect
            GameObject effect = Instantiate(
                ballBreakEffect,
                transform.position,
                Quaternion.identity
            );

            // Start particles
            ParticleSystem particles = effect.GetComponent<ParticleSystem>();

            if (particles != null)
            {
                particles.Play();
            }

            // Hide ball
            gameObject.SetActive(false);

            // Game Over
            gameManager.GameOver();

            // Destroy effect after particles finish
            Destroy(effect, 2f);
        }
    }
}