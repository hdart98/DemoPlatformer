using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingPlatform : MonoBehaviour
{
    public Transform startPos;
    public float speedFalling;
    Animator ani;
    bool isFalling;
    Rigidbody2D rb;
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        ani = GetComponent<Animator>();
        isFalling = false;
    }

    private void Start()
    {
        transform.position = startPos.position;
    }

    private void Update()
    {
        if (isFalling && rb)
        {
            rb.velocity = Vector2.down * speedFalling;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && collision.contacts[0].normal.y == -1 && ani)
        {
            Invoke("Falling", 0.5f);
        }
    }

    void Falling()
    {
        isFalling = true;
        ani.SetBool("isOff", true);
        Invoke("BackToStart", 2);
    }

    void BackToStart()
    {
        isFalling = false;
        if (rb) rb.velocity = Vector2.down*0;
        if (ani) ani.SetBool("isOff", false);
        transform.position = startPos.position;
    }
}
