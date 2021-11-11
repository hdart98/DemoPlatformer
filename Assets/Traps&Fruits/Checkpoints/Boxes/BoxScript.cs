using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxScript : MonoBehaviour
{
    public ParticleSystem breakBoxParticle;
    int countBreak;
    Animator ani;
    // Start is called before the first frame update
    void Start()
    {
        ani = GetComponent<Animator>();
        countBreak = 0;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && collision.contacts[0].normal.y >= 0.9f)
        {
            countBreak++;
            if (countBreak == 1 && ani) ani.SetTrigger("hit");
            if(countBreak == 2)
            {
               StartCoroutine(BreakBox());
            }
        }
    }

    IEnumerator BreakBox()
    {
        if (breakBoxParticle && AudioManager.Instance)
        {
            breakBoxParticle.Play();
            GetComponent<SpriteRenderer>().enabled = false;
            AudioManager.Instance.PlaySound("RockBreak");
            yield return new WaitForSeconds(breakBoxParticle.main.startLifetime.constantMax);
            Destroy(gameObject);
        }
    }
}
