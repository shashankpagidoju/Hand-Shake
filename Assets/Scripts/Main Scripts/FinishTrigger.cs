using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishTrigger : MonoBehaviour
{
    [Header("Level Number")]
    public int levelNumber;

    private bool finished = false;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (finished)
            return;

        PlayerState state = other.GetComponent<PlayerState>();

        if (state != null)
        {
            finished = true;

            Debug.Log("Finish Reached - Level " + levelNumber);

            if (LevelProgressManager.Instance != null)
            {
                LevelProgressManager.Instance.CompleteLevel(levelNumber);
            }

            Cursor.visible = true;

            SceneManager.LoadScene(
                SceneManager.GetActiveScene().buildIndex + 1
            );
        }
    }
}