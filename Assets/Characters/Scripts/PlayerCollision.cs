using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    Animator ani;
    bool isStayTrap;
    float timeTrap;

    private void Start()
    {
        ani = GetComponent<Animator>();
    }

    private void Update()
    {
        if (timeTrap > 0) timeTrap -= Time.deltaTime;
        if(isStayTrap && AudioManager.Instance && ani && timeTrap <= 0)
        {
            AudioManager.Instance.PlaySound("Trap");
            ani.SetTrigger("hit");
            timeTrap = 2;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Platform"))
        {
            transform.SetParent(collision.gameObject.transform);
        }
        if (collision.gameObject.CompareTag("Trap") && AudioManager.Instance && ani)
        {
            AudioManager.Instance.PlaySound("Trap");
            ani.SetTrigger("desappear");
            PlayerMovement.Instance.rb.bodyType = RigidbodyType2D.Static;
            StartCoroutine(GameController.Instance.BackToBackPoint());
            isStayTrap = true;
            timeTrap = 2;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Platform"))
        {
            transform.SetParent(null);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Fruits") && AudioManager.Instance)
        {
            AudioManager.Instance.PlaySound("Collect");
        }
        if (collision.CompareTag("Trap") && AudioManager.Instance && ani)
        {
            AudioManager.Instance.PlaySound("Trap");
            ani.SetTrigger("desappear");
            PlayerMovement.Instance.rb.bodyType = RigidbodyType2D.Static;
            StartCoroutine(GameController.Instance.BackToBackPoint());
            isStayTrap = true;
            timeTrap = 2;
        }
        if (collision.CompareTag("Checkpoint") && GameController.Instance)
        {
            collision.gameObject.GetComponent<CheckpointScript>().SetFlag(true);
            GameController.Instance.backPoint = collision.gameObject.transform.position;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Trap"))
        {
            isStayTrap = false;
        }
    }
}
