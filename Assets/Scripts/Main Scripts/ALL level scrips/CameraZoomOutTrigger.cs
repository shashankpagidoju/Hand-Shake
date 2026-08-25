using UnityEngine;

public class CameraZoomOutTrigger : MonoBehaviour
{
    public CameraZoomMachine cameraMachine;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            cameraMachine.StopZoom();
        }
    }
}