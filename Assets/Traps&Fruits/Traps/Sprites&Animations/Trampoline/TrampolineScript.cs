using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrampolineScript : MonoBehaviour
{
    public float jumpForce;
    bool isJump;
    private void Start()
    {
        isJump = true;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Player")&&collision.contacts[0].normal.y == -1 && isJump)
        {
            collision.gameObject.GetComponent<Rigidbody2D>().velocity = Vector2.up * jumpForce;
            isJump = false;
            collision.gameObject.GetComponent<Animator>().SetTrigger("jump");
            GetComponent<Animator>().SetTrigger("jump");
            StartCoroutine(JumpTime());
        }
    }

    IEnumerator JumpTime()
    {
        yield return new WaitForSeconds(0.5f);
        isJump = true;
    }
}
