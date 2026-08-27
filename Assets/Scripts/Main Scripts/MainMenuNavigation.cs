using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuNavigation : MonoBehaviour
{
    [Header("Panels")]
    public GameObject settingsPanel;

    public void PlayGame()
    {
        // Tutorial has NOT been completed yet
        if (PlayerPrefs.GetInt("TutorialShown", 0) == 0)
        {
            // First time → Tutorials
            SceneManager.LoadScene("tutorials");
        }
        else
        {
            // Tutorial already completed → Level Panel 1
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