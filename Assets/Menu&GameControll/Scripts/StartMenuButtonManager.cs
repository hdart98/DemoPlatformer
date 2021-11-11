using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenuButtonManager : MonoBehaviour
{
    public GameObject SettingPanel;

    public void LoadSceneChooseCharacter()
    {
        AudioManager.Instance.PlaySound("ButtonPress");
        SceneManager.LoadScene("ChooseCharacter");
    }

    public void SetActiveSettingPanel(bool value)
    {
        if (SettingPanel)
        {
            AudioManager.Instance.PlaySound("ButtonPress");
            SettingPanel.SetActive(value);
        }
    }

    public void QuitGame()
    {
        AudioManager.Instance.PlaySound("ButtonPress");
        Application.Quit();
    }
}
