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

    private float groundDistance = 0.4f;

    private bool isGrounded;

    public bool HasDoubleJump;

    private bool hasDoneDoubleJumpAlready;

    public void ApplyGravity()
    {
        this.isGrounded = Physics.CheckSphere(this.GroundCheck.position, this.groundDistance, this.GroundMask);

        if (this.isGrounded)
        {
            this.hasDoneDoubleJumpAlready = false;
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

        this.Velocity.y = Mathf.Sqrt(this.JumpHeight * -2f * this.Gravity);
    }

    public void Jump()
    {
        // Jump
        if ((Input.GetButtonDown("Jump") && this.isGrounded))
        {
            this.LocalJump();
        }
        else if (Input.GetButtonDown("Jump") && !this.isGrounded && this.HasDoubleJump && !hasDoneDoubleJumpAlready)
        {
            this.hasDoneDoubleJumpAlready = true;
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
}