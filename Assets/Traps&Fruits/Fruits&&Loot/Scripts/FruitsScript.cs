using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FruitsScript : MonoBehaviour
{
    public int rewardPoints;
    public GameObject collected;
    public GameObject changeValue;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            gameObject.SetActive(false);
            Instantiate(collected, gameObject.transform.position, Quaternion.identity);
            GameObject cvs = GameObject.FindObjectOfType<UIManagerScript>().gameObject;
            if (cvs)
            {
                GameObject gob = Instantiate(changeValue, cvs.transform);
                if (gob.GetComponent<RectTransform>())
                    gob.GetComponent<RectTransform>().position = Camera.main.WorldToScreenPoint(gameObject.transform.position);
                if (gob.GetComponent<ChangeValue>())
                    gob.GetComponent<ChangeValue>().SetValue("+" + rewardPoints);
            }
            if (GameController.Instance)
                GameController.Instance.IncreaseScore(rewardPoints);
            Destroy(gameObject);
        }
    }
}
