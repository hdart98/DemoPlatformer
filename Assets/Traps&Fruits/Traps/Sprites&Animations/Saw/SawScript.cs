using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SawScript : MonoBehaviour
{
    public Transform[] TagetPoints;
    public float speed;

    int curTagetIndex;
    // Start is called before the first frame update
    void Start()
    {
        transform.position = TagetPoints[0].position;
        if(TagetPoints.Length >= 2)
        curTagetIndex = 1;
    }

    // Update is called once per frame
    void Update()
    {
        if (TagetPoints.Length >= 2)
        {
            if (Vector3.Distance(transform.position, TagetPoints[curTagetIndex].position) > 0.05f)
            {
                transform.position += (TagetPoints[curTagetIndex].position - transform.position).normalized * speed * Time.deltaTime;
            } else
            {
                if (curTagetIndex == TagetPoints.Length - 1) curTagetIndex = 0;
                else curTagetIndex++;
            }
        }
    }
}
