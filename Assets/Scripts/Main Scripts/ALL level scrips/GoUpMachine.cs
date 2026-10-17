
using UnityEngine;

public class GoUpMachine : MonoBehaviour
{
    [Header("Movement")]
    [SerializeField] private bool useCustomStartY = false;
    [SerializeField] private float startY = -5f;
    [SerializeField] private float moveSpeed = 5f;

    [Header("Camera")]
    [SerializeField] private Camera targetCamera;
    [SerializeField] private float destroyPadding = 1f;

    private bool isMoving;

    private void Start()
    {
        // Keep the Scene position unless a custom Y is enabled.
        if (useCustomStartY)
        {
            Vector3 position = transform.position;
            position.y = startY;
            transform.position = position;
        }

        if (targetCamera == null)
            targetCamera = Camera.main;
    }

    public void Activate()
    {
        isMoving = true;
    }

    private void Update()
    {
        if (!isMoving)
            return;

        transform.position += Vector3.up * moveSpeed * Time.deltaTime;

        if (targetCamera == null)
            return;

        Vector3 viewportPosition =
            targetCamera.WorldToViewportPoint(transform.position);

        if (viewportPosition.y >
            1f + destroyPadding / targetCamera.orthographicSize)
        {
            Destroy(gameObject);
        }
    }
}
