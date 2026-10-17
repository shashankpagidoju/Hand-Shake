
using UnityEngine;
using System.Collections;

public class GoUpMachine : MonoBehaviour
{
    [Header("Movement")]
    [SerializeField] private float startY = -5.38f;
    [SerializeField] private float moveSpeed = 5f;

    [Header("Camera")]
    [SerializeField] private Camera targetCamera;
    [SerializeField] private float destroyPadding = 1f;

    private bool isMoving = false;

    private void Start()
    {
        Vector3 position = transform.position;
        position.y = startY;
        transform.position = position;

        if (targetCamera == null)
            targetCamera = Camera.main;
    }

    public void Activate()
    {
        if (!isMoving)
            isMoving = true;
    }

    private void Update()
    {
        if (!isMoving)
            return;

        transform.position += Vector3.up * moveSpeed * Time.deltaTime;

        if (targetCamera != null)
        {
            Vector3 viewportPosition =
                targetCamera.WorldToViewportPoint(transform.position);

            if (viewportPosition.y > 1f + destroyPadding / targetCamera.orthographicSize)
            {
                Destroy(gameObject);
            }
        }
    }
}
