using UnityEngine;

public class PointTrigger : MonoBehaviour
{
    public MazeDisappear mazeDisappear;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            mazeDisappear.DisappearFor5Seconds();
        }
    }
}