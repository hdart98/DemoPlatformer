using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectedScripts : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Invoke("DestroyGameObject", 0.5f);
    }

    void DestroyGameObject()
    {
        Destroy(gameObject);
    }
}
