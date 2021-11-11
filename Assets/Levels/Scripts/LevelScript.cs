using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelScript : MonoBehaviour
{
    public Transform start;
    public int timeLevel;
    public string level;
    public bool playStartGameSound;

    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1;
        if (GameController.Instance)
        {
            Instantiate(GameController.Instance.players[GameController.Instance.playerIndex], start.position, Quaternion.identity);
            
            GameController.Instance.backPoint = start.position;
        }
        

        if (AudioManager.Instance && playStartGameSound == true)
        {
            AudioManager.Instance.PlaySound("StartGame");
        }
        if (PlayerMovement.Instance && PlayerMovement.Instance.rb)
        {
            PlayerMovement.Instance.rb.bodyType = RigidbodyType2D.Dynamic;
        }

        if (UIManagerScript.Instance)
        {
            UIManagerScript.Instance.txt_Level.text = "Level "+level;
            UIManagerScript.Instance.txt_Time.text = timeLevel.ToString();
            StartCoroutine(Clock());
        }
        if (CameraFollow.Instance)
        {
            CameraFollow.Instance.FollowAndBound();
        }
    }

    IEnumerator Clock()
    {
        yield return new WaitForSeconds(1);
        if (timeLevel > 0)
        {
            timeLevel--;
            UIManagerScript.Instance.txt_Time.text = timeLevel.ToString();
            StartCoroutine(Clock());
        }
        else
        {
            UIManagerScript.Instance.GameOverPanel("GAME OVER");
            if (AudioManager.Instance)
            {
                AudioManager.Instance.PlaySound("Dead");
            }
        }
    }
}
