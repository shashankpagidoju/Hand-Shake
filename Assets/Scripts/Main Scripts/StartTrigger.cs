using UnityEngine;
using UnityEngine.InputSystem;

public class StartTrigger : MonoBehaviour
{
    public MouseFollow player;

    private PlayerState state;
    private Collider2D startCollider;

    void Start()
    {
        state = player.GetComponent<PlayerState>();
        startCollider = GetComponent<Collider2D>();

        // Every new level starts with cursor visible
        state.canMove = false;

        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }

    void Update()
    {
        // Player has NOT started yet
        if (!state.canMove)
        {
            // Keep cursor visible
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;

            if (Mouse.current.leftButton.wasPressedThisFrame)
            {
                Vector2 mousePos =
                    Camera.main.ScreenToWorldPoint(
                        Mouse.current.position.ReadValue()
                    );

                if (startCollider.OverlapPoint(mousePos))
                {
                    // Start controlling the ball
                    state.canMove = true;

                    // Hide cursor
                    Cursor.visible = false;
                    Cursor.lockState = CursorLockMode.Locked;
                }
            }
        }
    }
}