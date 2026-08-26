using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Collider2D))]
public class PlayerCollision : MonoBehaviour
{
    private Rigidbody2D rb;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();

        // Keep the player Kinematic
        rb.bodyType = RigidbodyType2D.Kinematic;

        rb.gravityScale = 0f;
        rb.collisionDetectionMode = CollisionDetectionMode2D.Continuous;
        rb.interpolation = RigidbodyInterpolation2D.Interpolate;
        rb.useFullKinematicContacts = true;
        rb.constraints = RigidbodyConstraints2D.FreezeRotation;
    }
}