using UnityEngine;

public class PlayerJump : MonoBehaviour
{
    public float JumpHeight = 5f;
    public float DistanceToMaxHeight = 4f;
    public float SpeedHorizontal = 8f;
    public float PressTimeToMaxJump = 0.2f;

    public LayerMask GroundLayers;
    public Transform GroundCheck;
    public Vector2 CheckBoxSize = new Vector2(0.6f, 0.1f);

    public float WallSlideSpeed = 2f;
    
    private Rigidbody2D rb;
    private CollisionDetection collisionDetection;
    private float lastVelocityY;
    private float jumpStartedTime;
    private bool isGrounded;
    private bool isJumping;

    bool IsWallSliding => collisionDetection != null && collisionDetection.IsTouchingFront && !isGrounded;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        collisionDetection = GetComponent<CollisionDetection>();
    }

    void FixedUpdate()
    {
        CheckGround();

        if (IsPeakReached()) TweakGravity();

        if (IsWallSliding) SetWallSlide();
    }

    public void OnJumpStarted()
    {
        if (isGrounded || IsWallSliding)
        {
            isJumping = true;
            SetGravity(); 
            
            float jumpForce = GetJumpForce();
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
            jumpStartedTime = Time.time;
        }
    }

    public void OnJumpFinished()
    {
        if (isJumping && rb.linearVelocity.y > 0)
        {
            float timeDiff = Mathf.Max(Time.time - jumpStartedTime, 0.01f);
            float pressFactor = Mathf.Clamp01(timeDiff / PressTimeToMaxJump);
            
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, rb.linearVelocity.y * pressFactor);
        }
        isJumping = false;
    }

    private void CheckGround()
    {
        isGrounded = Physics2D.OverlapBox(GroundCheck.position, CheckBoxSize, 0f, GroundLayers);
    }

    private void SetGravity()
    {
        float gravity = (2 * JumpHeight * Mathf.Pow(SpeedHorizontal, 2)) / Mathf.Pow(DistanceToMaxHeight, 2);
        rb.gravityScale = gravity / 9.81f;
    }

    private void TweakGravity()
    {
        rb.gravityScale *= 1.2f;
    }

    private float GetJumpForce()
    {
        return (2 * JumpHeight * SpeedHorizontal) / DistanceToMaxHeight;
    }

    private bool IsPeakReached()
    {
        bool reached = (lastVelocityY >= 0 && rb.linearVelocity.y < 0);
        lastVelocityY = rb.linearVelocity.y;
        return reached;
    }

    private void SetWallSlide()
    {
        rb.linearVelocity = new Vector2(rb.linearVelocity.x, Mathf.Max(rb.linearVelocity.y, -WallSlideSpeed));
    }

    private void OnDrawGizmos()
    {
        if (GroundCheck != null)
        {
            Gizmos.color = isGrounded ? Color.green : Color.red;
            Gizmos.DrawWireCube(GroundCheck.position, CheckBoxSize);
        }
    }
}
