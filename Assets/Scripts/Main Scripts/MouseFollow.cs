using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody2D))]
public class MouseFollow : MonoBehaviour
{
    private Rigidbody2D rb;
    private PlayerState state;

    private Vector3 lastMousePosition;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        state = GetComponent<PlayerState>();

        lastMousePosition = Input.mousePosition;
    }

    void FixedUpdate()
    {
        if (!state.canMove)
            return;

        // Read mouse movement this frame
        Vector2 mouseDelta = Mouse.current.delta.ReadValue();

        // Reverse controls
        if (state.reverseControls)
            mouseDelta *= -1;

        // Move player
        Vector2 movement = mouseDelta * state.currentSpeed * Time.fixedDeltaTime * 0.1f;

        rb.MovePosition(rb.position + movement);
    }
}