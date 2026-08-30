using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuNavigation : MonoBehaviour
{
    [Header("Panels")]
    public GameObject settingsPanel;

    public void PlayGame()
    {
        // Every time PLAY is pressed → Tutorials
        SceneManager.LoadScene("tutorials");
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