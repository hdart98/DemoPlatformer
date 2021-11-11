using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikedBallScript : MonoBehaviour
{
    public float leftPushRange;
    public float rightPushRange;
    public float velocityThreshold;

    float velocity;
    Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        velocity = velocityThreshold;
    }

    private void Update()
    {
        if (transform.rotation.z > rightPushRange)
        {
            velocity = -velocityThreshold;
        }
        else
        {
            if(transform.rotation.z < leftPushRange)
            {
                velocity = velocityThreshold;
            }
        }
        rb.angularVelocity = velocity;
    }

}
