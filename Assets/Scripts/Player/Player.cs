using System.Collections;

using Cinemachine;

using UnityEngine;

public class Player : MonoBehaviour
{
    public Movement Movement;

    public Rotation Rotation;

    public Interaction Interaction;

    public bool HasPackage;

    public GameManager GameManager;

    public GameObject RiggedPlayerPrefab;

    public GameObject ThirdPersonCamera;

    public GameObject BodyPosition;

    public CinemachineFreeLook ThirdPersonCameraFreeLook;

    public float RespawnTime;

    public bool isDead;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void Update()
    {
        if (this.isDead == false)
        {
            this.Movement.ApplyGravity();
            if (UIManager.IsMenuOn) return;

            this.Movement.Move();
            this.Rotation.RotateCamera();
            this.Movement.Jump();
        }
    }

    public void Death()
    {
        StartCoroutine(Respawn(RespawnTime));
        this.HasPackage = false;
    }

    private IEnumerator Respawn(float waitTime)
    {
        this.Movement.CharacterController.enabled = false;
        this.isDead = true;
        this.Interaction.gameObject.SetActive(false);
        this.ThirdPersonCamera.GetComponent<Camera>().enabled = true;
        GameObject DeadBody = Instantiate(RiggedPlayerPrefab, this.BodyPosition.transform.position, Quaternion.identity, this.BodyPosition.transform);
        this.ThirdPersonCameraFreeLook.Follow = DeadBody.transform;
        this.ThirdPersonCameraFreeLook.LookAt = DeadBody.transform;

        yield return new WaitForSeconds(waitTime);

        this.ThirdPersonCameraFreeLook.Follow = this.BodyPosition.transform;
        this.ThirdPersonCameraFreeLook.LookAt = this.BodyPosition.transform;
        Destroy(DeadBody);
        this.ThirdPersonCamera.GetComponent<Camera>().enabled = false;
        this.Interaction.gameObject.SetActive(true);
        this.transform.position = this.GameManager.ElevatorTransform.position;
        this.Movement.CharacterController.enabled = true;
        this.isDead = false;
    }

    private void SpawnInElevator()
    {
        StartCoroutine(Respawn(RespawnTime));
    }

    public void NextMission()
    {
        this.SpawnInElevator();
        this.HasPackage = false;
    }
}