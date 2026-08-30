using UnityEngine;
using UnityEngine.SceneManagement;

public class EndCredit : MonoBehaviour
{
    [Header("Settings")]
    public float timeBeforeMainMenu = 10f;

    private float timer;

    void Start()
    {
        timer = timeBeforeMainMenu;
    }

    void Update()
    {
        timer -= Time.deltaTime;

        if (timer <= 0f)
        {
            SceneManager.LoadScene("Main Menu");
        }
    }
}