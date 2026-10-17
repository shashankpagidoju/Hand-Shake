
using UnityEngine;

public class GoRightTrigger : MonoBehaviour
{
    [SerializeField] private GoRightMachine goRightMachine;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            if (goRightMachine != null)
            {
                goRightMachine.Activate();
            }
        }
    }
}
