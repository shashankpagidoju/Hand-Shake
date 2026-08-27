using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuNavigation : MonoBehaviour
{
    [Header("Panels")]
    public GameObject settingsPanel;

    public void PlayGame()
    {
        // Tutorial not completed yet
        if (PlayerPrefs.GetInt("TutorialShown", 0) == 0)
        {
            SceneManager.LoadScene("tutorials");
        }
        else
        {
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
    }
}