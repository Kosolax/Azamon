using UnityEngine;

public class Player : MonoBehaviour
{
    public Movement Movement;

    public Rotation Rotation;

    public Interaction Interaction;

    public bool HasPackage;

    public GameManager GameManager;

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

    public void Death()
    {
        this.SpawnInElevator();
        this.HasPackage = false;
    }

    private void SpawnInElevator()
    {
        this.Movement.CharacterController.enabled = false;
        this.transform.position = this.GameManager.ElevatorTransform.position;
        this.Movement.CharacterController.enabled = true;
    }

    public void NextMission()
    {
        this.SpawnInElevator();
        this.HasPackage = false;
    }
}