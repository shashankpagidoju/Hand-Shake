using UnityEngine;
using System.Collections;

public class DisappearObject : MonoBehaviour
{
    [Header("Settings")]
    public string targetTag = "Disappear";
    public float disappearTime = 3f;

    private bool playerInside = false;
    private Coroutine disappearRoutine;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.GetComponent<PlayerState>() != null)
        {
            playerInside = true;

            if (disappearRoutine != null)
                StopCoroutine(disappearRoutine);

            disappearRoutine = StartCoroutine(DisappearAfterTime());
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.GetComponent<PlayerState>() != null)
        {
            playerInside = false;

            if (disappearRoutine != null)
            {
                StopCoroutine(disappearRoutine);
                disappearRoutine = null;
            }
        }
    }

    IEnumerator DisappearAfterTime()
    {
        yield return new WaitForSeconds(disappearTime);

        if (playerInside)
        {
            GameObject[] objects = GameObject.FindGameObjectsWithTag(targetTag);

            foreach (GameObject obj in objects)
            {
                obj.SetActive(false);
            }
        }
    }
}