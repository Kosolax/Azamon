using UnityEngine;

public class Player : MonoBehaviour
{
    public Movement Movement;

    public Rotation Rotation;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void Update()
    {
        this.Movement.ApplyGravity();
        if (UIManager.IsMenuOn) return;
        this.Movement.Move();
        this.Rotation.RotateCamera();
        this.Movement.Jump();
    }
}