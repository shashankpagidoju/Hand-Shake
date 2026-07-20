using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections;

[RequireComponent(typeof(Rigidbody2D))]
public class MouseFollow : MonoBehaviour
{
    private Rigidbody2D rb;
    private PlayerState state;

    [Header("Movement")]
    public float smoothing = 15f;
    public float deadZone = 2f;

    private Vector2 velocity;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        state = GetComponent<PlayerState>();

        if (PlayerPrefs.GetInt("Restarted", 0) == 1)
        {
            StartCoroutine(LockCursorNextFrame());
        }
    }

    IEnumerator LockCursorNextFrame()
    {
        yield return null;

        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    void FixedUpdate()
    {
        if (!state.canMove)
            return;

        Vector2 input = Mouse.current.delta.ReadValue();

        if (input.magnitude < deadZone)
            input = Vector2.zero;

        if (state.reverseControls)
            input *= -1;

        Vector2 direction = input.normalized;

        Vector2 targetVelocity = direction * state.currentSpeed;

        velocity = Vector2.Lerp(
            velocity,
            targetVelocity,
            smoothing * Time.fixedDeltaTime
        );

        if (input == Vector2.zero)
            velocity = Vector2.zero;

        rb.MovePosition(rb.position + velocity * Time.fixedDeltaTime);
    }
}