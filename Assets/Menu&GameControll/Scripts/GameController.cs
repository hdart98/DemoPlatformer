using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public static GameController Instance;
    public GameObject[] players;
    [HideInInspector] public int score;
    [HideInInspector] public int playerIndex;
    [HideInInspector] public bool isGameOver;
    [HideInInspector] public Vector3 backPoint;
    //[HideInInspector] public bool isDead;

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

    void Start()
    {
        score = 0;
        playerIndex = 0;
        isGameOver = false;
    }

    public void IncreaseScore(int rewardPoints)
    {
        score += rewardPoints;
        if (UIManagerScript.Instance)
        {
            UIManagerScript.Instance.txt_Score.text = score.ToString();
        }
    }

    public IEnumerator BackToBackPoint()
    {
        yield return new WaitForSeconds(0.5f);
        if (PlayerMovement.Instance)
        {
            PlayerMovement.Instance.transform.position = backPoint;
            if (PlayerMovement.Instance.ani)
                PlayerMovement.Instance.ani.SetTrigger("appear");
            PlayerMovement.Instance.rb.bodyType = RigidbodyType2D.Dynamic;
        }
    }

    public void EndPos()
    {
        if (SceneManager.GetActiveScene().buildIndex < SceneManager.sceneCountInBuildSettings - 1 && UIManagerScript.Instance && AudioManager.Instance)
        {
            UIManagerScript.Instance.EndLevelPanel(true);
        }
        else
        {
            UIManagerScript.Instance.GameOverPanel("YOU WIN");
            AudioManager.Instance.PlaySound("Victory");
        }
    }
}
