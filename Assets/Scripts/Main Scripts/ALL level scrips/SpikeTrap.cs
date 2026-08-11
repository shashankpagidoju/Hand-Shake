using UnityEngine;

public class SpikeTrap : MonoBehaviour
{
    [Header("Spike")]
    public Transform spike;
    public Transform pointA;

    [Header("Movement")]
    private const float SPEED = 5f;
    private const float WAIT_TIME = 0.2f;

    private Vector3 pointB;

    private bool playerInside = false;
    private bool movingToA = false;
    private bool movingToB = false;

    private float waitTimer = 0f;

    void Start()
    {
        // Remember the spike's original position
        pointB = spike.position;
    }

    void Update()
    {
        if (!playerInside)
            return;

        // Move toward Point A
        if (movingToA)
        {
            spike.position = Vector3.MoveTowards(
                spike.position,
                pointA.position,
                SPEED * Time.deltaTime
            );

            if (Vector3.Distance(spike.position, pointA.position) < 0.01f)
            {
                movingToA = false;
                movingToB = true;
                waitTimer = WAIT_TIME;
            }
        }

        // Small pause before returning
        else if (movingToB)
        {
            waitTimer -= Time.deltaTime;

            if (waitTimer <= 0f)
            {
                spike.position = Vector3.MoveTowards(
                    spike.position,
                    pointB,
                    SPEED * Time.deltaTime
                );

                if (Vector3.Distance(spike.position, pointB) < 0.01f)
                {
                    movingToB = false;
                    movingToA = true;
                }
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.GetComponent<PlayerState>() != null)
        {
            playerInside = true;

            if (!movingToA && !movingToB)
            {
                movingToA = true;
            }
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.GetComponent<PlayerState>() != null)
        {
            playerInside = false;

            // Return spike to original position
            movingToA = false;
            movingToB = false;

            spike.position = pointB;
        }
    }
}