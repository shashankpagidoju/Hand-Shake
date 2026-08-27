using UnityEngine;
using UnityEngine.SceneManagement;

public class TutorialNavigation : MonoBehaviour
{
    public static TutorialNavigation Instance;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public bool HasSeenTutorial()
    {
        return PlayerPrefs.GetInt("TutorialShown", 0) == 1;
    }

    public void CompleteTutorial()
    {
        PlayerPrefs.SetInt("TutorialShown", 1);

        // Level 1 is available after tutorial
        if (PlayerPrefs.GetInt("HighestUnlockedLevel", 0) < 1)
        {
            PlayerPrefs.SetInt("HighestUnlockedLevel", 1);
        }

        PlayerPrefs.Save();

        Debug.Log("Tutorial Completed!");
    }

    public void OpenLevelPanel()
    {
        // Mark tutorial as completed ONLY here
        CompleteTutorial();

        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

        SceneManager.LoadScene("levels page - 1");
    }
}