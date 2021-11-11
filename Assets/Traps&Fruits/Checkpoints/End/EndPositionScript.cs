using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndPositionScript : MonoBehaviour
{
    Animator ani;
    public GameObject changeValue;
    public int rewardPoints;
    // Start is called before the first frame update
    void Start()
    {
        ani = GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player") && ani && GameController.Instance)
        {
            GameObject cvs = GameObject.FindObjectOfType<UIManagerScript>().gameObject;
            if (cvs)
            {
                GameObject gob = Instantiate(changeValue, cvs.transform);
                if (gob.GetComponent<RectTransform>())
                    gob.GetComponent<RectTransform>().position = Camera.main.WorldToScreenPoint(gameObject.transform.position);
                if (gob.GetComponent<ChangeValue>())
                    gob.GetComponent<ChangeValue>().SetValue("+" + rewardPoints);
            }
            if (AudioManager.Instance)
            {
                AudioManager.Instance.PlaySound("End");
            }
            ani.SetBool("isPressed", true);
            Invoke("End", 2);
        }
    }

    void End()
    {
        if (GameController.Instance)
        GameController.Instance.EndPos();
    }
}
