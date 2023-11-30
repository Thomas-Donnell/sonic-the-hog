using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private float horizontal;
    private float jumpingPower = 16f;
    private bool isFacingRight = true;
    public static bool isGrounded = true;
    [SerializeField] private float initialSpeed = 2f;
    [SerializeField] private float speed = 2f;
    [SerializeField] private float acceleration = .02f;
    [SerializeField] private float maxSpeed = 10f;
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private Animator animator;

    Subject subject;

    void Start()
    {
        subject = new Subject();
        new SceneObserver(subject);
    }

    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        if(horizontal == 0)
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
        if(speed < maxSpeed)
        {
            speed += acceleration;
        }
        rb.velocity = new Vector2(horizontal * speed, rb.velocity.y);

        isGrounded = IsGrounded();
        animator.SetFloat("speed", speed);
        animator.SetBool("grounded", isGrounded);
        
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
}


