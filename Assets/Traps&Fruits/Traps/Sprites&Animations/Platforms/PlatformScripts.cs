using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformScripts : MonoBehaviour
{
    public Transform startPos;
    public Transform endPos;
    public float speed;

    Animator ani;
    Rigidbody2D rb;
    bool isMove;

    void Awake()
    {
        ani = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    // Start is called before the first frame update
    void Start()
    {
        transform.position = startPos.position;
        isMove = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (isMove)
        {
            if (Vector3.Distance(transform.position, endPos.position) > 0.05)
            {
                transform.position += (endPos.position - transform.position).normalized * speed * Time.deltaTime;
                ani.SetBool("isOn", true);
            }
            else ani.SetBool("isOn", false);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Player") && collision.contacts[0].normal.y <= -0.9)
        {
            isMove = true;
        }
    }
}
