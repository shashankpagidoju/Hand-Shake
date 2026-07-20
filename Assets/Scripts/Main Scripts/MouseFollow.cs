using UnityEngine;
using UnityEngine.InputSystem;

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

        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    void FixedUpdate()
    {
        if (!state.canMove)
            return;

        // Mouse movement
        Vector2 input = Mouse.current.delta.ReadValue();

        // Dead zone
        if (input.magnitude < deadZone)
            input = Vector2.zero;

        // Reverse controls
        if (state.reverseControls)
            input *= -1;

        // Direction only
        Vector2 direction = input.normalized;

        // Target velocity
        Vector2 targetVelocity = direction * state.currentSpeed;

        // Smooth but responsive
        velocity = Vector2.Lerp(
            velocity,
            targetVelocity,
            smoothing * Time.fixedDeltaTime
        );

        // Stop immediately if no input
        if (input == Vector2.zero)
            velocity = Vector2.zero;

        // Move player
        rb.MovePosition(rb.position + velocity * Time.fixedDeltaTime);
    }
}