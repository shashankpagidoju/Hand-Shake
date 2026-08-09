using UnityEngine;
using System.Collections;

public class RevealTrigger : MonoBehaviour
{
    public GameObject hiddenPath;
    public float waitTime = 3f;

    private bool playerInside = false;
    private Coroutine revealRoutine;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.GetComponent<PlayerState>() != null)
        {
            playerInside = true;
            revealRoutine = StartCoroutine(RevealPath());
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.GetComponent<PlayerState>() != null)
        {
            playerInside = false;

            if (revealRoutine != null)
                StopCoroutine(revealRoutine);
        }
    }

    IEnumerator RevealPath()
    {
        yield return new WaitForSeconds(waitTime);

        if (playerInside)
        {
            hiddenPath.SetActive(true);
        }
    }
}