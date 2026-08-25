using UnityEngine;

public class CameraZoomInTrigger : MonoBehaviour
{
    public CameraZoomMachine cameraMachine;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            cameraMachine.StartZoom();
        }
    }
}