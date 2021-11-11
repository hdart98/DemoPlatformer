using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireScript : MonoBehaviour
{
    Animator ani;
    // Start is called before the first frame update
    void Awake()
    {
        ani = GetComponent<Animator>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player")&&collision.contacts[0].normal.y < -0.9)
        {
            ani.SetTrigger("hit");


        }
    }
}
