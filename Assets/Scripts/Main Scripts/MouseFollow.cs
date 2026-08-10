using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody2D))]
public class MouseFollow : MonoBehaviour
{
    private Rigidbody2D rb;
    private PlayerState state;

    // Fixed values - DO NOT change
    private const float MOVE_MULTIPLIER = 0.08f;
    private const float SMOOTH_TIME = 0.035f;

    private Vector2 mouseInput;
    private Vector2 velocity;
    private Vector2 smoothVelocity;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        state = GetComponent<PlayerState>();

        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }

    void Update()
    {
        if (!state.canMove)
            return;

        // Collect ALL mouse movement between physics frames.
        // This prevents small/slow mouse movements from being lost.
        mouseInput += Mouse.current.delta.ReadValue();
    }

    void FixedUpdate()
    {
        if (!state.canMove)
        {
            velocity = Vector2.zero;
            mouseInput = Vector2.zero;
            return;
        }

        // Get the accumulated mouse movement
        Vector2 input = mouseInput;

        // Reset immediately so the same movement isn't used twice
        mouseInput = Vector2.zero;

        // Reverse controls
        if (state.reverseControls)
            input *= -1f;

        // Convert mouse movement into movement speed.
        // IMPORTANT: Do NOT normalize the input.
        Vector2 targetVelocity = input * state.currentSpeed * MOVE_MULTIPLIER;

        // Prevent extremely fast mouse movements from exceeding game speed
        targetVelocity = Vector2.ClampMagnitude(
            targetVelocity,
            state.currentSpeed
        );

        // Very smooth but responsive movement
        velocity = Vector2.SmoothDamp(
            velocity,
            targetVelocity,
            ref smoothVelocity,
            SMOOTH_TIME
        );

        // Move the ball
        rb.MovePosition(
            rb.position + velocity * Time.fixedDeltaTime
        );
    }
}