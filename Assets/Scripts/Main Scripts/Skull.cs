using UnityEngine;
using UnityEngine.Video;

public class Skull : MonoBehaviour
{
    [Header("Video")]
    public VideoPlayer skullVideo;

    [Header("Reset")]
    public Transform startPoint;

    private Rigidbody2D rb;
    private MouseFollow mouseFollow;

    private bool skullTriggered = false;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        mouseFollow = GetComponent<MouseFollow>();
    }

    private void Start()
    {
        if (skullVideo != null)
        {
            skullVideo.Stop();
            skullVideo.loopPointReached += VideoFinished;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (skullTriggered)
            return;

        if (other.CompareTag("Skull"))
        {
            Debug.Log("SKULL WALL HIT!");

            skullTriggered = true;

            // Stop player movement
            if (mouseFollow != null)
                mouseFollow.enabled = false;

            if (rb != null)
            {
                rb.linearVelocity = Vector2.zero;
                rb.angularVelocity = 0f;
            }

            // Play video
            if (skullVideo != null)
            {
                skullVideo.gameObject.SetActive(true);
                skullVideo.Play();
            }
        }
    }

    private void VideoFinished(VideoPlayer vp)
    {
        Debug.Log("SKULL VIDEO FINISHED!");

        // NOW reset the ball
        if (startPoint != null)
        {
            transform.position = startPoint.position;
        }

        if (rb != null)
        {
            rb.linearVelocity = Vector2.zero;
            rb.angularVelocity = 0f;
        }

        // Hide video
        skullVideo.Stop();
        skullVideo.gameObject.SetActive(false);

        // Allow movement again
        if (mouseFollow != null)
            mouseFollow.enabled = true;

        skullTriggered = false;
    }

    private void OnDestroy()
    {
        if (skullVideo != null)
        {
            skullVideo.loopPointReached -= VideoFinished;
        }
    }
}