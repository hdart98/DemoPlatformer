using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckpointScript : MonoBehaviour
{
    Animator ani;
    private void Start()
    {
        ani = GetComponent<Animator>();
    }

    public void SetFlag(bool value)
    {
        ani.SetBool("isOut", value);
    }
}
