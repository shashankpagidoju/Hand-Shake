using UnityEngine;
using UnityEngine.InputSystem;

public class StartTrigger : MonoBehaviour
{
    public MouseFollow player;

    private Collider2D startCollider;

    void Start()
    {
        startCollider = GetComponent<Collider2D>();

        // Every time the level loads:
        // cursor is visible and player cannot move
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;

        player.GetComponent<PlayerState>().canMove = false;
    }

    void Update()
    {
        PlayerState state = player.GetComponent<PlayerState>();

        // Already started
        if (state.canMove)
            return;

        // Get current mouse position
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(
            Mouse.current.position.ReadValue()
        );

        // Cursor touches blue Start box
        if (startCollider.OverlapPoint(mousePos))
        {
            state.canMove = true;

            // Hide and lock cursor
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
        }
    }
}