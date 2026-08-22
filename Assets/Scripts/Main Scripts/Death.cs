using UnityEngine;
using System.Collections;

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

                // Run coroutine from GameManager
                gameManager.StartCoroutine(
                    WaitForEffect(particles, effect)
                );
            }
            else
            {
                gameManager.GameOver();
                Destroy(effect);
            }

            // Hide ball AFTER starting coroutine
            gameObject.SetActive(false);
        }
    }

    private IEnumerator WaitForEffect(
        ParticleSystem particles,
        GameObject effect)
    {
        // Wait until the complete particle effect finishes
        while (particles.IsAlive(true))
        {
            yield return null;
        }

        // Destroy the effect
        Destroy(effect);

        // NOW show Game Over
        gameManager.GameOver();
    }
}