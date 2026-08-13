using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelPanelNavigation : MonoBehaviour
{
    public void OpenMainMenu()
    {
        SceneManager.LoadScene("Main Menu");
    }

    public void OpenPanel1()
    {
        SceneManager.LoadScene("levels page - 1");
    }

    public void OpenPanel2()
    {
        SceneManager.LoadScene("levels page - 2");
    }

    public void OpenPanel3()
    {
        SceneManager.LoadScene("levels page - 3");
    }

    public void OpenPanel4()
    {
        SceneManager.LoadScene("levels page - 4");
    }
}