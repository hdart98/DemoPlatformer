using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartMenuScripts : MonoBehaviour
{
    
    // Start is called before the first frame update
    void Start()
    {
        AudioManager.Instance.PlaySound("StartSoundTrack");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
