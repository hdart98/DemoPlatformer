using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockSpikeHeadScript : MonoBehaviour
{
    public float timeBlink;
    public Transform[] positionTagets;
    public float speed;

    BoxCollider2D bc2d;
    int curTagetIndex;
    float deltaTimeBink;
    Animator ani;
    Rigidbody2D rb;
    // Start is called before the first frame update
    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        ani = GetComponent<Animator>();
        deltaTimeBink = timeBlink;
        bc2d = GetComponent<BoxCollider2D>();
        if (positionTagets.Length >= 2)
        {
            transform.position = positionTagets[0].position;
            curTagetIndex = 1;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(positionTagets.Length >= 2 && rb)
        {
            if(Vector2.Distance(transform.position,positionTagets[curTagetIndex].position) > 0.1f)
            {
                rb.MovePosition(transform.position + (positionTagets[curTagetIndex].position - transform.position).normalized * speed * Time.deltaTime);
            }
            else
            {
                if (curTagetIndex == positionTagets.Length - 1) curTagetIndex = 0;
                else curTagetIndex++;
            }
        }
        deltaTimeBink -= Time.deltaTime;
        if(deltaTimeBink < 0)
        {
            ani.SetTrigger("blink");
            deltaTimeBink = timeBlink;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (collision.contacts[0].normal.y >= 0.999f) ani.SetTrigger("botHit");
            if (collision.contacts[0].normal.y <= -0.999f) ani.SetTrigger("topHit");
            if (collision.contacts[0].normal.x >= 0.999) ani.SetTrigger("leftHit");
            if (collision.contacts[0].normal.x <= -0.999) ani.SetTrigger("rightHit");
            bc2d.isTrigger = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            bc2d.isTrigger = false;
        }
    }
}
