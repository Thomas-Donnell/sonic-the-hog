using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private float horizontal;
    private float jumpingPower = 16f;
    private bool isFacingRight = true;
    private bool allowMovement = true;
    [SerializeField] private float initialSpeed = 2f;
    [SerializeField] private float speed = 2f;
    [SerializeField] private float acceleration = .02f;
    [SerializeField] private float maxSpeed = 10f;
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private Animator animator;

    void Update()
    {
        if (!allowMovement) return;

        horizontal = Input.GetAxisRaw("Horizontal");
        if (horizontal == 0)
        {
            speed = initialSpeed;
        }

        if (Input.GetButtonDown("Jump") && IsGrounded())
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpingPower);
        }

        if (Input.GetButtonUp("Jump") && rb.velocity.y > 0f)
        {
            rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * 0.5f);
        }

        Flip();
    }

    private void FixedUpdate()
    {
        if (!allowMovement) return;

        if (speed < maxSpeed)
        {
            speed += acceleration;
        }
        rb.velocity = new Vector2(horizontal * speed, rb.velocity.y);

        animator.SetFloat("speed", Mathf.Abs(speed));
    }

    private bool IsGrounded()
    {
        return Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);
    }

    private void Flip()
    {
        if (isFacingRight && horizontal < 0f || !isFacingRight && horizontal > 0f)
        {
            isFacingRight = !isFacingRight;
            Vector3 localScale = transform.localScale;
            localScale.x *= -1f;
            transform.localScale = localScale;
        }
    }

    public void DisableMovementTemporarily(float duration)
    {
        allowMovement = false;
        Invoke("EnableMovement", duration);
    }

    private void EnableMovement()
    {
        allowMovement = true;
    }
}
