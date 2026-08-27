using UnityEngine;
using UnityEngine.SceneManagement;

public class EndCreditTrigger : MonoBehaviour
{
    public Transform player;
    public string endCreditsSceneName = "End Credits";

    private Collider2D finishCollider;
    private bool triggered = false;

    void Start()
    {
        finishCollider = GetComponent<Collider2D>();
    }

    void Update()
    {
        if (triggered)
            return;

        if (player == null || finishCollider == null)
            return;

        // Check if the player's position is inside the finish area
        if (finishCollider.OverlapPoint(player.position))
        {
            triggered = true;

            SceneManager.LoadScene(endCreditsSceneName);
        }
    }
}