
using UnityEngine;

public class GoUpTrigger : MonoBehaviour
{
    [SerializeField] private GoUpMachine goUpMachine;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            goUpMachine.Activate();
        }
    }
}
