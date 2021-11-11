using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraFollow : MonoBehaviour
{
    public static CameraFollow Instance;

    CinemachineVirtualCamera cvc;
    CinemachineConfiner ccfn;
    GameObject player;
    Collider2D bound;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
            return;
        }
    }

    public void FollowAndBound()
    {
        cvc = GetComponent<CinemachineVirtualCamera>();
        player = GameObject.FindGameObjectWithTag("Player");
        ccfn = GetComponent<CinemachineConfiner>();
        if(GameObject.FindGameObjectWithTag("Bound"))
        bound = GameObject.FindGameObjectWithTag("Bound").GetComponent<Collider2D>();
        if (cvc && player)
        {
            cvc.m_Follow = player.transform;
        }
        if (ccfn && bound)
        {
            ccfn.m_BoundingShape2D = bound;
        }
    }
}
