using UnityEngine;
using UnityEngine.SceneManagement;

public class TutorialNavigation : MonoBehaviour
{
    public void OpenLevelPanel()
    {
        PlayerPrefs.SetInt("TutorialShown", 1);

        if (PlayerPrefs.GetInt("HighestUnlockedLevel", 0) < 1)
        {
            PlayerPrefs.SetInt("HighestUnlockedLevel", 1);
        }

        PlayerPrefs.Save();

        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

        SceneManager.LoadScene("levels page - 1");
    }
}