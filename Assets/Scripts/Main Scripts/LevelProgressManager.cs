using UnityEngine;

public class LevelProgressManager : MonoBehaviour
{
    public static LevelProgressManager Instance;

    private const string HighestLevelKey = "HighestUnlockedLevel";

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

    public int GetHighestUnlockedLevel()
    {
        return PlayerPrefs.GetInt(HighestLevelKey, 1);
    }

    public void CompleteLevel(int levelNumber)
    {
        int highestLevel = GetHighestUnlockedLevel();

        if (levelNumber >= highestLevel)
        {
            PlayerPrefs.SetInt(HighestLevelKey, levelNumber + 1);
        }

        PlayerPrefs.SetInt("LevelCompleted_" + levelNumber, 1);
        PlayerPrefs.Save();
    }

    public bool IsLevelUnlocked(int levelNumber)
    {
        return levelNumber <= GetHighestUnlockedLevel();
    }

    public bool IsLevelCompleted(int levelNumber)
    {
        return PlayerPrefs.GetInt("LevelCompleted_" + levelNumber, 0) == 1;
    }

    private void ResetLevelProgress()
    {
        // Delete all completed levels
        for (int i = 1; i <= 16; i++)
        {
            PlayerPrefs.DeleteKey("LevelCompleted_" + i);
        }

        // Only Level 1 is unlocked
        PlayerPrefs.SetInt(HighestLevelKey, 1);

        PlayerPrefs.Save();

        Debug.Log("FINAL LEVEL PROGRESS RESET");
    }
}