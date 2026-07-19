using UnityEngine;

public class StartTrigger : MonoBehaviour
{
    public MouseFollow player;

    void Update()
    {
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        if (GetComponent<Collider2D>().OverlapPoint(mousePos))
        {
            PlayerState state = player.GetComponent<PlayerState>();

            state.canMove = true;

            // Hide the cursor
            Cursor.visible = false;

            enabled = false;
        }
    }
}