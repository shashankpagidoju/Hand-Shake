using UnityEngine;

public class RandomPointTrigger : MonoBehaviour
{
    public GameObject[] points;

    void Start()
    {
        ActivateRandomPoint();
    }

    void ActivateRandomPoint()
    {
        // Turn all points OFF
        foreach (GameObject point in points)
        {
            point.SetActive(false);
        }

        // Pick one random point
        int randomIndex = Random.Range(0, points.Length);

        // Turn that point ON
        points[randomIndex].SetActive(true);

        Debug.Log("Active Point: " + points[randomIndex].name);
    }
}