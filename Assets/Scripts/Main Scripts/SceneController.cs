using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    public static SceneController instance;

    [Header("Level Music")]
    public AudioSource levelMusic;

    // Change these if your 4 levels have different Build Indexes
    public int firstLevelBuildIndex = 1;
    public int lastLevelBuildIndex = 4;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);

            SceneManager.sceneLoaded += OnSceneLoaded;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        int currentBuildIndex = scene.buildIndex;

        // Check if current scene is one of the 4 levels
        bool isLevel =
            currentBuildIndex >= firstLevelBuildIndex &&
            currentBuildIndex <= lastLevelBuildIndex;

        if (isLevel)
        {
            // Start music only if it isn't already playing
            if (levelMusic != null && !levelMusic.isPlaying)
            {
                levelMusic.Play();
            }
        }
        else
        {
            // Stop music when leaving the 4 levels
            if (levelMusic != null && levelMusic.isPlaying)
            {
                levelMusic.Stop();
            }
        }
    }

    public void NextLevel()
    {
        SceneManager.LoadSceneAsync(
            SceneManager.GetActiveScene().buildIndex + 1
        );
    }

    public void LoadScene(string sceneName)
    {
        SceneManager.LoadSceneAsync(sceneName);
    }

    private void OnDestroy()
    {
        if (instance == this)
        {
            SceneManager.sceneLoaded -= OnSceneLoaded;
        }
    }
}