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

    private bool canGhostJump;

    private bool isJumping;

    private float groundDistance = 0.4f;

    public bool isGrounded;

    public Inventory Inventory;

    public bool hasDoneDoubleJumpAlready { get; set; }

    public void ApplyGravity()
    {
        this.isGrounded = Physics.CheckSphere(this.GroundCheck.position, this.groundDistance, this.GroundMask);

        if (this.isGrounded)
        {
            this.Inventory.HasUsedDoubleJump = false;
        }

        // When we touch the ground we make sure to reset velocity for the next jump
        // Since we can detect to have touch the ground before we really touched the ground we still let a little velocity to keep going down
        if (this.isGrounded && this.Velocity.y < 0)
        {
            this.Velocity.y = -2f;
        }

        // Gravity
        this.Velocity.y += this.Gravity * Time.deltaTime;
        this.CharacterController.Move(this.Velocity * Time.deltaTime);
    }

    private void LocalJump()
    {
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
        if (Input.GetButtonDown("Jump") && this.isGrounded || Input.GetButtonDown("Jump") && this.canGhostJump == true && this.timer > 0f)
        {
            this.timerBis = this.InitialJumpTimer;
            this.canGhostJump = false;
            this.timer = 0f;
            this.LocalJump();
        }
        else if (Input.GetButtonDown("Jump") && !this.isGrounded && this.Inventory.HasDoubleJump && !this.Inventory.HasUsedDoubleJump)
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
        this.CharacterController.Move(move * this.Speed * Time.deltaTime);
    }

    private void Start()
    {
        this.canGhostJump = false;
        this.isJumping = false;
    }

    private void FixedUpdate()
    {
        if (this.isGrounded)
        {
            this.CharacterController.stepOffset = 0.3f;
        }

        this.realVelocity = this.CharacterController.velocity;

        if (!this.isGrounded)
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
        else if (this.isGrounded && this.isJumping)
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
        else if (!this.isGrounded && this.isJumping)
        {
            this.canGhostJump = false;
        }
        else if (this.isGrounded && !this.isJumping)
        {
            this.canGhostJump = true;
            this.timer = this.ghostJumpTime;
        }
    }
}