using UnityEngine;
using UnityEngine.SceneManagement;

public class TutorialNavigation : MonoBehaviour
{
    public void OpenLevelPanel()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

        SceneManager.LoadScene("levels page - 1");
    }
}