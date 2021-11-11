using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class ChangeValue : MonoBehaviour
{
    float destroyTime = 1f;
    public Text text;
    // Start is called before the first frame update
    void Start()
    {
        transform.DOMoveY(transform.position.y + 80, 0.5f);
    }

    // Update is called once per frame
    void Update()
    {
        if (destroyTime > 0) destroyTime -= Time.deltaTime;
        else Destroy(gameObject);
    }

    public void SetValue(string txt)
    {
        if (text)
        {
            text.text = txt;
        }
    }
}
