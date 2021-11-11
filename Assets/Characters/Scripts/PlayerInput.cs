using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    PlayerMovement pmove;
    float xDirection;
    bool isJump;
    private void Awake()
    {
        pmove = GetComponent<PlayerMovement>();
        isJump = false;
    }

    void Update()
    {
        xDirection = Input.GetAxisRaw("Horizontal");
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            isJump = true;
        }
    }

    private void FixedUpdate()
    {
        if(pmove)
        {
            pmove.Run(xDirection);
            if (isJump)
            {
                pmove.Jump();
                isJump = false;
            }
        }
    }
}
