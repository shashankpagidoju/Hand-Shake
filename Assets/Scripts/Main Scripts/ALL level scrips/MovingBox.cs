using UnityEngine;

public class MovingBox : MonoBehaviour
{
    [Header("Points")]
    public Transform pointA;
    public Transform pointB;

    private const float SPEED = 2f;

    void Update()
    {
        // Move toward Point B
        transform.position = Vector3.MoveTowards(
            transform.position,
            pointB.position,
            SPEED * Time.deltaTime
        );

        // Reached Point B
        if (Vector3.Distance(transform.position, pointB.position) < 0.01f)
        {
            // Instantly return to Point A
            transform.position = pointA.position;
        }
    }
}