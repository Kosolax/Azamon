using System.Collections;

using Cinemachine;

using UnityEngine;

public class Player : MonoBehaviour
{
    public Movement Movement;

    public Rotation Rotation;

    public Interaction Interaction;

    public GameManager GameManager;

    public GameObject DeadBodies;

    public GameObject DeadBody;

    public GameObject RiggedPlayerPrefab;

    public GameObject ThirdPersonCamera;

    public GameObject BodyPosition;

    public CinemachineFreeLook ThirdPersonCameraFreeLook;

    public float RespawnTime;

    public bool isDead;

    public Inventory Inventory;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        this.ThirdPersonCamera.GetComponent<AudioListener>().enabled = false;
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
        this.Inventory.HasPackage = false;
    }

    private IEnumerator Respawn(float waitTime)
    {
        Vector3 startVelocity = new Vector3(this.Movement.CharacterController.velocity.x, this.Movement.Velocity.y, this.Movement.CharacterController.velocity.z);
        this.Movement.CharacterController.enabled = false;
        this.isDead = true;
        this.Interaction.gameObject.SetActive(false);
        this.ThirdPersonCamera.GetComponent<AudioListener>().enabled = true;
        this.ThirdPersonCamera.GetComponent<Camera>().enabled = true;
        this.DeadBody = Instantiate(RiggedPlayerPrefab, this.BodyPosition.transform.position, this.transform.rotation);
        this.DeadBody.transform.parent = this.DeadBodies.transform;

        Rigidbody[] rigidbodies;
        rigidbodies = this.DeadBody.GetComponentsInChildren<Rigidbody>();

        foreach (var child in rigidbodies)
        {
            child.velocity = startVelocity;
        }

        //DeadBody.GetComponent<CameraAnchor>().Anchor.GetComponent<Rigidbody>().velocity = startVelocity * 10;
        this.ThirdPersonCameraFreeLook.Follow = this.DeadBody.GetComponent<CameraAnchor>().Anchor.transform;
        this.ThirdPersonCameraFreeLook.LookAt = this.DeadBody.GetComponent<CameraAnchor>().Anchor.transform;

        yield return new WaitForSeconds(waitTime);

        this.Movement.Velocity.y = 0;
        this.ThirdPersonCameraFreeLook.Follow = this.BodyPosition.transform;
        this.ThirdPersonCameraFreeLook.LookAt = this.BodyPosition.transform;
        Destroy(this.DeadBody.GetComponent<CameraAnchor>());
        this.ThirdPersonCamera.GetComponent<AudioListener>().enabled = false;
        this.ThirdPersonCamera.GetComponent<Camera>().enabled = false;
        this.DeadBody.layer = LayerMask.NameToLayer("Ground");
        this.Interaction.gameObject.SetActive(true);
        this.transform.position = this.GameManager.ElevatorTransform.position;
        this.Movement.CharacterController.enabled = true;
        this.isDead = false;
        this.DeadBody = null;
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
        this.Inventory.HasPackage = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "platform")
        {
            transform.parent = other.transform.parent.transform;

        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "platform")
        {
            transform.parent = null;

        }
    }

}