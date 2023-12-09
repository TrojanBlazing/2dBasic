using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms;

public class PlayerMovement : MonoBehaviour
  {
    private float horizontal;
    private float speed = 8f;
    private float jumpingPower = 16f;
    private bool isFacingRight = true;
     private bool DoubleJump=false;
    private float DoubleJumpSpeed = 10f;

    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;

    bool candash=true;
    bool isDashing;
    private float Dashspeed=20f;
    private float DashTimer=0.2f;
    private float DashCooldown=1f;

    

    void Update()
    {
        if(isDashing)
        {
            return;
        }
        horizontal = Input.GetAxisRaw("Horizontal");
        if (IsGrounded() && !Input.GetButtonDown("Jump"))
        {
            DoubleJump = true;
        }
        Jump();

       
        Flip();
        Dashing();



    }

    private void FixedUpdate()
    {
        if (isDashing)
        {
            return;
        }
        rb.velocity = new Vector2(horizontal * speed, rb.velocity.y);
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
 
   private  IEnumerator Dash()
    {
        candash = false;
        isDashing = true;
        float OriginalGravitiy = rb.gravityScale;
        rb.gravityScale = 0f;
         rb.velocity = new Vector2(transform.localScale.x * Dashspeed, 0f);
        yield return new WaitForSeconds(DashTimer);
        rb.gravityScale = OriginalGravitiy;
        isDashing = false;
        yield return new WaitForSeconds(DashCooldown);
        candash = true;
    }
    private void Dashing()
    {
        if(Input.GetKey(KeyCode.LeftShift)&&candash)
        {
            StartCoroutine(Dash());
        }
    }
    private void Jump()
    {
        if (Input.GetButtonDown("Jump"))
        {
            if (IsGrounded())
            {
                rb.velocity = new Vector2(rb.velocity.x, jumpingPower);
                DoubleJump = false;
            }
            else if (DoubleJump)
            {
                rb.velocity = new Vector2(rb.velocity.x, DoubleJumpSpeed);
                DoubleJump = false;
            }
        }
        if (Input.GetButtonUp("Jump") && rb.velocity.y > 0f)
        {
            rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * 0.5f);
        }

    }
}

