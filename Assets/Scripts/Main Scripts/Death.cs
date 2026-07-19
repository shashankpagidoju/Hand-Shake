using UnityEngine;

public class Death : MonoBehaviour
{
    public GameManager gameManager;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Death"))
        {
            gameManager.GameOver();
        }
    }
}