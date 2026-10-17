
using UnityEngine;

public class GoLeftMachine : MonoBehaviour
{
    [Header("Movement")]
    [SerializeField] private bool useCustomStartX = false;
    [SerializeField] private float startX = 5f;
    [SerializeField] private float moveSpeed = 5f;

    [Header("Camera")]
    [SerializeField] private Camera targetCamera;
    [SerializeField] private float destroyPadding = 1f;

    private bool isMoving;

    private void Start()
    {
        if (useCustomStartX)
        {
            Vector3 position = transform.position;
            position.x = startX;
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

        transform.position +=
            Vector3.left * moveSpeed * Time.deltaTime;

        if (targetCamera == null)
            return;

        Vector3 viewportPosition =
            targetCamera.WorldToViewportPoint(transform.position);

        float padding =
            destroyPadding /
            (targetCamera.orthographicSize * targetCamera.aspect);

        if (viewportPosition.x < -padding)
        {
            Destroy(gameObject);
        }
    }
}
