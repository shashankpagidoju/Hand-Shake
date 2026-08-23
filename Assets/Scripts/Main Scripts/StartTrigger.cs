using UnityEngine;
using UnityEngine.InputSystem;

public class StartTrigger : MonoBehaviour
{
    public MouseFollow player;

    void Update()
    {
        // Skip if player can already move
        if (player.GetComponent<PlayerState>().canMove)
            return;

        // Only respond to LEFT CLICK
        if (Mouse.current.leftButton.wasPressedThisFrame)
        {
            Vector2 mousePos = Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue());

            if (GetComponent<Collider2D>().OverlapPoint(mousePos))
            {
                PlayerState state = player.GetComponent<PlayerState>();

                state.canMove = true;

                Cursor.visible = false;
                Cursor.lockState = CursorLockMode.Locked;
            }
        }
    }
}