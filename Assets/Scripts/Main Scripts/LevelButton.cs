using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelButton : MonoBehaviour
{
    [Header("Level")]
    public int levelNumber;

    [Header("UI")]
    public GameObject lockedImage;
    public GameObject completedImage;

    private Button button;

    private void Start()
    {
        button = GetComponent<Button>();
        UpdateButton();
    }

    private void OnEnable()
    {
        UpdateButton();
    }

    private void UpdateButton()
    {
        if (LevelProgressManager.Instance == null)
            return;

        bool unlocked =
            LevelProgressManager.Instance.IsLevelUnlocked(levelNumber);

        bool completed =
            LevelProgressManager.Instance.IsLevelCompleted(levelNumber);

        // Show LOCKED only when the level is locked
        if (lockedImage != null)
            lockedImage.SetActive(!unlocked);

        // Show COMPLETED only when the level has been completed
        if (completedImage != null)
            completedImage.SetActive(completed);

        // Locked levels cannot be clicked
        if (button != null)
            button.interactable = unlocked;
    }

    public void OpenLevel()
    {
        if (LevelProgressManager.Instance == null)
            return;

        if (!LevelProgressManager.Instance.IsLevelUnlocked(levelNumber))
        {
            Debug.Log("Level " + levelNumber + " is locked.");
            return;
        }

        SceneManager.LoadScene("level-" + levelNumber);
    }
}