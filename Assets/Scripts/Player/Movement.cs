using System.Collections.Generic;

using UnityEngine;

public class Movement : MonoBehaviour
{
    public CharacterController CharacterController;

    public float Gravity;

    public Transform GroundCheck;

    public LayerMask GroundMask;

    public AudioSource JumpAudioSource;

    public float JumpHeight;

    public float Speed;

    public Vector3 Velocity;

    public Vector3 realVelocity;

    public float ghostJumpTime;

    private float timer;

    private float timerBis;

    public float InitialJumpTimer;

    public bool canGhostJump;

    private bool isJumping;

    public float GroundDistance = 0.4f;
    public float JumpDistance = 0.4f;

    public bool isGrounded;
    public bool IsAbleToJump;

    public Inventory Inventory;

    public List<AudioClip> JumpSounds;

    public float FallVelocity;

    public GameManager GameManager;

    public Transform JumpCheck;

    public bool hasDoneDoubleJumpAlready { get; set; }

    public void ApplyGravity()
    {
        this.IsAbleToJump = Physics.CheckSphere(this.JumpCheck.position, this.JumpDistance, this.GroundMask);
        this.isGrounded = Physics.CheckSphere(this.GroundCheck.position, this.GroundDistance, this.GroundMask);

        if (this.isGrounded)
        {
            if (this.Velocity.y <= this.FallVelocity)
            {
                this.GameManager.MissionLose();
                return;
            }
        }

        if (this.IsAbleToJump)
        {
            this.Inventory.HasUsedDoubleJump = false;
        }

        // When we touch the ground we make sure to reset velocity for the next jump
        // Since we can detect to have touch the ground before we really touched the ground we still let a little velocity to keep going down
        if (this.isGrounded && this.Velocity.y < 0)
        {
            this.Velocity.y = -3f;
        }

        // Gravity
        this.Velocity.y += this.Gravity * Time.deltaTime;
        this.CharacterController.Move(this.Velocity * Time.deltaTime);
    }

    private void LocalJump()
    {
        this.JumpAudioSource.clip = this.JumpSounds[Random.Range(0, this.JumpSounds.Count)];

        if (this.JumpAudioSource.clip != null)
        {
            this.JumpAudioSource.Play();
        }
        this.isJumping = true;
        this.Velocity.y = Mathf.Sqrt(this.JumpHeight * -2f * this.Gravity);
    }

    public void Jump()
    {
        // Jump
        if (Input.GetButtonDown("Jump") && this.IsAbleToJump || Input.GetButtonDown("Jump") && this.canGhostJump == true && this.timer > 0f)
        {
            this.timerBis = this.InitialJumpTimer;
            this.canGhostJump = false;
            this.timer = 0f;
            this.LocalJump();
        }
        else if (Input.GetButtonDown("Jump") && !this.IsAbleToJump && this.Inventory.HasDoubleJump && !this.Inventory.HasUsedDoubleJump)
        {
            this.Inventory.HasUsedDoubleJump = true;
            this.LocalJump();
        }
    }

    public void Move()
    {
        // Move locally
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = this.transform.right * x + this.transform.forward * z;
        if (this.CharacterController.enabled)
        {
            this.CharacterController.Move(Vector3.ClampMagnitude(move,1f) * this.Speed * Time.deltaTime);
        }
    }

    private void Start()
    {
        this.canGhostJump = false;
        this.isJumping = false;
    }

    private void FixedUpdate()
    {
        if (this.IsAbleToJump)
        {
            this.CharacterController.stepOffset = 0.3f;
        }

        this.realVelocity = this.CharacterController.velocity;

        if (!this.IsAbleToJump)
        {
            //the best i found for not clipping and still not climbing walls like a spider
            this.CharacterController.stepOffset = 0.002f;
            if (this.timer > 0f && this.canGhostJump == true)
            {
                this.timer -= Time.deltaTime;
            }
            else
            {
                this.canGhostJump = false;
            }
        }
        else if (this.IsAbleToJump && this.isJumping)
        {
            if (this.timerBis > 0f)
            {
                this.timerBis -= Time.deltaTime;
            }
            else
            {
                this.isJumping = false;
            }
        }
        else if (!this.IsAbleToJump && this.isJumping)
        {
            this.canGhostJump = false;
        }
        else if (this.IsAbleToJump && !this.isJumping)
        {
            this.canGhostJump = true;
            this.timer = this.ghostJumpTime;
        }
    }
}