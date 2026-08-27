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

    private void Awake()
    {
        button = GetComponent<Button>();
    }

    private void Start()
    {
        UpdateButton();
    }

    private void OnEnable()
    {
        // Wait until LevelProgressManager exists
        Invoke(nameof(UpdateButton), 0.1f);
    }

    private void UpdateButton()
    {
        if (LevelProgressManager.Instance == null)
            return;

        bool unlocked =
            LevelProgressManager.Instance.IsLevelUnlocked(levelNumber);

        bool completed =
            LevelProgressManager.Instance.IsLevelCompleted(levelNumber);

        // LOCKED image
        if (lockedImage != null)
            lockedImage.SetActive(!unlocked);

        // COMPLETED image
        if (completedImage != null)
            completedImage.SetActive(completed);

        // Enable/disable button
        if (button != null)
            button.interactable = unlocked;
    }

    public void OpenLevel()
    {
        if (LevelProgressManager.Instance == null)
        {
            Debug.LogError("LevelProgressManager is missing!");
            return;
        }

        if (!LevelProgressManager.Instance.IsLevelUnlocked(levelNumber))
        {
            Debug.Log("Level " + levelNumber + " is LOCKED.");
            return;
        }

        string sceneName = "level-" + levelNumber;

        Debug.Log("Opening " + sceneName);

        SceneManager.LoadScene(sceneName);
    }
}