using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject gameOverPanel;

    void Start()
    {
        Time.timeScale = 1f;

        if (PlayerPrefs.GetInt("Restarted", 0) == 1)
        {
            PlayerState state = FindFirstObjectByType<PlayerState>();

            if (state != null)
                state.canMove = true;

            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;

            PlayerPrefs.SetInt("Restarted", 0);
        }
        else
        {
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }
    }

    public void GameOver()
    {
        gameOverPanel.SetActive(true);

        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;

        Time.timeScale = 0f;
    }

    public void Restart()
    {
        PlayerPrefs.SetInt("Restarted", 1);

        Time.timeScale = 1f;

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}