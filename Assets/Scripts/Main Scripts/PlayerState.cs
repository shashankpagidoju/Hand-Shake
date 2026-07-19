using UnityEngine;

public class PlayerState : MonoBehaviour
{
    [Header("Movement")]
    public bool canMove = false;
    public bool reverseControls = false;

    [Header("Speed")]
    public float baseSpeed = 15f;
    public float currentSpeed = 15f;

    [Header("Sensitivity")]
    public float baseSensitivity = 1f;
    public float currentSensitivity = 1f;

    [Header("Other")]
    public float stopDistance = 0.1f;

    void Awake()
    {
        currentSpeed = baseSpeed;
        currentSensitivity = baseSensitivity;
    }
}