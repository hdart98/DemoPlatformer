using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public ParticleSystem dust;
    public Transform checkWallPos;
    public Transform checkGroundPos;
    public LayerMask groundLayer;
    public float checkRadius;
    bool isWall;
    bool isOnGround;
    public float runSpeed;
    public float jumpForce;
    [HideInInspector] public Rigidbody2D rb;
    [HideInInspector] public Animator ani;
    bool isReadyJump;
    bool isReadyDoubleJump;
    bool isJumpWall;
    public static PlayerMovement Instance;
    void Awake()
    {
        if (Instance==null)
        {
            Instance = this;
        }
    }

    private void Start()
    {
        isJumpWall = false;
        isReadyDoubleJump = false;
        isReadyJump = false;
        ani = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        if (rb)
        {
            rb.bodyType = RigidbodyType2D.Dynamic;
        }
        ani.SetTrigger("appear");
    }

    private void Update()
    {
        ani.SetFloat("yVelocity", rb.velocity.y);
        isWall = Physics2D.OverlapCircle(checkWallPos.position, checkRadius, groundLayer);
        isOnGround = Physics2D.OverlapCircle(checkGroundPos.position, checkRadius, groundLayer);
        ani.SetBool("isOnGround", isOnGround);
        ani.SetBool("isWall", isWall);

        if (!isWall)
        {
            isJumpWall = true;
        }

        if (isOnGround)
        {
            isReadyJump = true;
            isReadyDoubleJump = false;
        }
        else
        {
            if (isJumpWall && isWall)
            {
                isReadyJump = true;
                isReadyDoubleJump = false;
            }
            else isReadyJump = false;
        }
    }

    public void Run(float xDirection)
    {
        if(rb && rb.bodyType != RigidbodyType2D.Static)
        {
            rb.velocity = new Vector2(runSpeed * xDirection, rb.velocity.y);
            if (xDirection != 0)
            {
                transform.localScale =
                new Vector3(xDirection * Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);
                ani.SetBool("isRun", true);
                if (isOnGround) dust.Play();
            } else ani.SetBool("isRun", false);
            
        }
    }

    public void Jump()
    {
        if (rb && rb.bodyType != RigidbodyType2D.Static)
        {
            if (isReadyJump)
            {
                if(AudioManager.Instance)
                    AudioManager.Instance.PlaySound("Jump");
                isReadyJump = false;
                dust.Play();
                rb.velocity = Vector2.up * jumpForce;
                ani.SetTrigger("jump");
                isReadyDoubleJump = true;
                isJumpWall = false;
            }
            else
            {
                if(isReadyDoubleJump&&!isWall)
                {
                    if (AudioManager.Instance)
                        AudioManager.Instance.PlaySound("Jump");
                    rb.velocity = Vector2.up * jumpForce;
                    ani.SetTrigger("doubleJump");
                    isReadyDoubleJump = false;
                }
            }
            
        }
    }
}
