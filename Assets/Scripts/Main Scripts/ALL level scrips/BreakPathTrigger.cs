using UnityEngine;

public class BreakPathTrigger : MonoBehaviour
{
    public PathManager pathManager;

    [Header("Path")]
    public GameObject pathToBreak;

    [Header("Invisible Blocker")]
    public GameObject invisibleBlock;

    [Header("Path Type")]
    public bool isPathA;

    private bool triggered = false;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (triggered)
            return;

        if (other.GetComponent<PlayerState>() == null)
            return;

        // PATH A
        if (isPathA)
        {
            if (pathManager.firstPathChosen)
                return;

            pathManager.ChoosePathA();

            BreakPath();
        }

        // PATH B
        else
        {
            if (pathManager.firstPathChosen)
                return;

            pathManager.ChoosePathB();

            BreakPath();
        }
    }

    private void BreakPath()
    {
        triggered = true;

        // Break visual path
        if (pathToBreak != null)
            pathToBreak.SetActive(false);

        // Activate ONLY this path's blocker
        if (invisibleBlock != null)
            invisibleBlock.SetActive(true);
    }
}