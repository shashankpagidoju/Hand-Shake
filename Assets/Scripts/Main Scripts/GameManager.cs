using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject gameOverPanel;

    void Start()
    {
        Time.timeScale = 1f;

        // Every time the scene loads,
        // player must use the Start box again.
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;

        PlayerState state = FindFirstObjectByType<PlayerState>();

        if (state != null)
            state.canMove = false;
    }

    public void GameOver()
    {
        gameOverPanel.SetActive(true);

        // Show cursor so player can click Restart
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;

        Time.timeScale = 0f;
    }

    public void Restart()
    {
        // Resume time before loading
        Time.timeScale = 1f;

        // Reload scene
        // StartTrigger will require the blue box again
        SceneManager.LoadScene(
            SceneManager.GetActiveScene().buildIndex
        );
    }
}