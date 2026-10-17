
using UnityEngine;

public class GoRightMachine : MonoBehaviour
{
    [Header("Movement")]
    [SerializeField] private bool useCustomStartX = false;
    [SerializeField] private float startX = -0.224f;
    [SerializeField] private float moveSpeed = 5f;

    [Header("Camera")]
    [SerializeField] private Camera targetCamera;
    [SerializeField] private float destroyPadding = 1f;

    private bool isMoving;
    private float movementStartX;

    private void Start()
    {
        // Keep the position placed in the Scene unless overridden.
        movementStartX = useCustomStartX
            ? startX
            : transform.position.x;

        Vector3 position = transform.position;
        position.x = movementStartX;
        transform.position = position;

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

        transform.position +=
            Vector3.right * moveSpeed * Time.deltaTime;

        if (targetCamera == null)
            return;

        Vector3 viewportPosition =
            targetCamera.WorldToViewportPoint(transform.position);

        if (viewportPosition.x >
            1f + destroyPadding / targetCamera.orthographicSize)
        {
            Destroy(gameObject);
        }
    }
}
