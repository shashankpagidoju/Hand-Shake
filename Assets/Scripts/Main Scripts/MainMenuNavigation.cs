using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuNavigation : MonoBehaviour
{
    [Header("Panels")]
    public GameObject settingsPanel;

    public void PlayGame()
    {
        // Check if tutorials have already been shown
        if (PlayerPrefs.GetInt("TutorialShown", 0) == 0)
        {
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
        settingsPanel.SetActive(true);
    }

    public void CloseSettings()
    {
        settingsPanel.SetActive(false);
    }

    public void ExitGame()
    {
        Application.Quit();

        Debug.Log("Game Exited");
    }
}