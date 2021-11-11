using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChooseCharacterController : MonoBehaviour
{
    public GameObject ButtonLeft;
    public GameObject ButtonRight;
    public GameObject[] characters;
    int icharacter = 0;

    private void Update()
    {
        if (characters.Length > 0)
        {
            for (int i = 0; i < characters.Length; i++)
            {
                if (i != icharacter)
                {
                    characters[i].SetActive(false);
                }
                else characters[i].SetActive(true);
            }

            if (icharacter == 0) ButtonLeft.SetActive(false);
            else ButtonLeft.SetActive(true);
            if (icharacter == characters.Length-1) ButtonRight.SetActive(false);
            else ButtonRight.SetActive(true);
        }
    }

    public void PressButtonLeft()
    {
        AudioManager.Instance.PlaySound("ButtonPress");
        icharacter -= 1;
    }

    public void PressButtonRight()
    {
        AudioManager.Instance.PlaySound("ButtonPress");
        icharacter += 1;
    }

    public void PressButtonBack()
    {
        AudioManager.Instance.PlaySound("ButtonPress");
        SceneManager.LoadScene("StartMenu");
    }

    public void PressButtonPlay()
    {
        GameController.Instance.playerIndex = icharacter;
        AudioManager.Instance.PlaySound("ButtonPress");
        AudioManager.Instance.StopSound("StartSoundTrack");
        SceneManager.LoadScene(2);
    }
}
