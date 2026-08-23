using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody2D))]
public class MouseFollow : MonoBehaviour
{
    private Rigidbody2D rb;
    private PlayerState state;

    private const float MOVE_MULTIPLIER = 0.08f;
    private const float SMOOTH_TIME = 0.035f;

    private Vector2 mouseInput;
    private Vector2 velocity;
    private Vector2 smoothVelocity;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        state = GetComponent<PlayerState>();
    }

    void Update()
    {
        if (!state.canMove)
            return;

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

        Vector2 input = mouseInput;
        mouseInput = Vector2.zero;

        if (state.reverseControls)
            input *= -1f;

        Vector2 targetVelocity =
            input * state.currentSpeed * MOVE_MULTIPLIER;

        targetVelocity = Vector2.ClampMagnitude(
            targetVelocity,
            state.currentSpeed
        );

        velocity = Vector2.SmoothDamp(
            velocity,
            targetVelocity,
            ref smoothVelocity,
            SMOOTH_TIME
        );

        rb.MovePosition(
            rb.position + velocity * Time.fixedDeltaTime
        );
    }
}