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

        // Cursor is visible until the player touches the Start box
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }

    void FixedUpdate()
    {
        // Ball cannot move until Start box is activated
        if (!state.canMove)
            return;

        Vector2 input = Mouse.current.delta.ReadValue();

        // Dead zone
        if (input.magnitude < deadZone)
            input = Vector2.zero;

        // Reverse controls
        if (state.reverseControls)
            input *= -1;

        Vector2 direction = input.normalized;

        Vector2 targetVelocity = direction * state.currentSpeed;

        // Smooth movement
        velocity = Vector2.Lerp(
            velocity,
            targetVelocity,
            smoothing * Time.fixedDeltaTime
        );

        // Stop when mouse stops
        if (input == Vector2.zero)
            velocity = Vector2.zero;

        rb.MovePosition(
            rb.position + velocity * Time.fixedDeltaTime
        );
    }
}