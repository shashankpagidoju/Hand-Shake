using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject gameOverPanel;




    public void GameOver()
    {
        gameOverPanel.SetActive(true);

        Cursor.visible = true;

        FindFirstObjectByType<MouseFollow>().enabled = false;

        Time.timeScale = 0f;
    }

    public void Restart()
    {
        Cursor.visible = true;

        Time.timeScale = 1f;

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}