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

        Vector2 input = Mouse.current.delta.ReadValue();

        // Dead Zone
        if (input.magnitude < deadZone)
            input = Vector2.zero;

        // Reverse Controls
        if (state.reverseControls)
            input *= -1;

        // Apply game sensitivity
        input *= state.currentSensitivity;

        // Limit extremely high mouse movement
        input = Vector2.ClampMagnitude(input, 20f);

        // Scale input to game speed
        Vector2 targetVelocity = input * state.currentSpeed * 0.08f;

        // Smooth movement 
        float t = 1f - Mathf.Exp(-smoothing * Time.fixedDeltaTime);
        velocity = Vector2.Lerp(velocity, targetVelocity, t);

        // Stop quickly when there is no movement
        if (input == Vector2.zero)
            velocity = Vector2.zero;

        rb.MovePosition(rb.position + velocity * Time.fixedDeltaTime);
    }
}