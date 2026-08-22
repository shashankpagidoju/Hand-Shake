using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuNavigation : MonoBehaviour
{
    public void PlayGame()
    {
        // Check if tutorials have already been shown
        if (PlayerPrefs.GetInt("TutorialShown", 0) == 0)
        {
            // Mark tutorials as shown
            PlayerPrefs.SetInt("TutorialShown", 1);
            PlayerPrefs.Save();

            // First time → Tutorials
            SceneManager.LoadScene("tutorials");
        }
        else
        {
            // Tutorials already completed → Level Panel
            SceneManager.LoadScene("levels page - 1");
        }
    }

    public void OpenSettings()
    {
        // Your settings panel logic can go here
    }

    public void ExitGame()
    {
        Application.Quit();

        // This works only in the built game.
        // In Unity Editor it won't visibly close the game.
        Debug.Log("Game Exited");
    }
}