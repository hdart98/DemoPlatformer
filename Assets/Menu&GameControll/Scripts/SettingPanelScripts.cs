using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingPanelScripts : MonoBehaviour
{
    public Slider volume;
    private void OnEnable()
    {
        if (volume && AudioManager.Instance)
            volume.value = AudioManager.Instance.volume;
    }

    void Update()
    {
        if(volume && AudioManager.Instance)
        AudioManager.Instance.volume = volume.value;
    }
}
