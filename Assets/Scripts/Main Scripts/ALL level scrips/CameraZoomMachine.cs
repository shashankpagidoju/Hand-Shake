using UnityEngine;
using System.Collections;

public class CameraZoomMachine : MonoBehaviour
{
    [Header("Player / Ball")]
    public Transform ball;

    [Header("Zoom Settings")]
    public float zoomSize = 3f;
    public float zoomSpeed = 4f;

    [Header("Shake Settings")]
    public float shakeAmount = 0.08f;
    public float shakeSpeed = 25f;

    [Header("Return Settings")]
    public float returnSpeed = 4f;

    private Camera cam;

    private Vector3 normalPosition;
    private float normalSize;

    private bool zoomMode = false;
    private bool returning = false;

    private void Awake()
    {
        cam = GetComponent<Camera>();

        normalPosition = transform.position;
        normalSize = cam.orthographicSize;
    }

    private void LateUpdate()
    {
        if (zoomMode)
        {
            FollowBallWithShake();
        }
    }

    private void FollowBallWithShake()
    {
        if (ball == null)
            return;

        // Camera follows the ball
        Vector3 targetPosition = new Vector3(
            ball.position.x,
            ball.position.y,
            transform.position.z
        );

        // Smooth following
        Vector3 smoothPosition = Vector3.Lerp(
            transform.position,
            targetPosition,
            Time.deltaTime * zoomSpeed
        );

        // Camera shake
        float shakeX = (Mathf.PerlinNoise(Time.time * shakeSpeed, 0f) - 0.5f) * shakeAmount;
        float shakeY = (Mathf.PerlinNoise(0f, Time.time * shakeSpeed) - 0.5f) * shakeAmount;

        smoothPosition += new Vector3(shakeX, shakeY, 0f);

        transform.position = smoothPosition;

        // Zoom in
        cam.orthographicSize = Mathf.Lerp(
            cam.orthographicSize,
            zoomSize,
            Time.deltaTime * zoomSpeed
        );
    }

    public void StartZoom()
    {
        returning = false;
        zoomMode = true;
    }

    public void StopZoom()
    {
        zoomMode = false;
        returning = true;

        StartCoroutine(ReturnCamera());
    }

    private IEnumerator ReturnCamera()
    {
        while (returning)
        {
            transform.position = Vector3.Lerp(
                transform.position,
                normalPosition,
                Time.deltaTime * returnSpeed
            );

            cam.orthographicSize = Mathf.Lerp(
                cam.orthographicSize,
                normalSize,
                Time.deltaTime * returnSpeed
            );

            // Stop when close enough
            if (Vector3.Distance(transform.position, normalPosition) < 0.01f &&
                Mathf.Abs(cam.orthographicSize - normalSize) < 0.01f)
            {
                transform.position = normalPosition;
                cam.orthographicSize = normalSize;

                returning = false;
            }

            yield return null;
        }
    }
}