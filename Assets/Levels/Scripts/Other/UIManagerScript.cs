using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIManagerScript : MonoBehaviour
{
    public static UIManagerScript Instance;
    public GameObject panel_GameOver;
    public GameObject panel_Setting;
    public GameObject panel_EndLevel;
    public Text gameOverTxt;
    public Slider volume;
    public Text txt_Time;
    public Text txt_Level;
    public Text txt_Score;
    public Text txt_GameOverScore;
    
    PlayerMovement playerMove;
    float xDirection;
    bool isJump;

    private void Awake()
    {
        if(Instance == null)
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
        if (GameController.Instance)
            txt_Score.text = GameController.Instance.score.ToString();
        isJump = false;
        xDirection = 0;
        playerMove = FindObjectOfType<PlayerMovement>();
        if (volume && AudioManager.Instance)
            volume.value = AudioManager.Instance.volume;
    }

    void Update()
    {
        if(volume && AudioManager.Instance)
        AudioManager.Instance.volume = volume.value;
    }

    private void FixedUpdate()
    {
        if (playerMove)
        {
            playerMove.Run(xDirection);
            if (isJump)
            {
                playerMove.Jump();
                isJump = false;
            }
        }
    }

    public void SetDirection(float dir)
    {
        xDirection = dir;
    }

    public void JumpButton()
    {
        isJump = true;
    }

    public void SetActivePanelSetting(bool value)
    {
        if (AudioManager.Instance)
        {
            AudioManager.Instance.PlaySound("ButtonPress");
        }
        panel_Setting.SetActive(value);
        if (value) Time.timeScale = 0;
        else Time.timeScale = 1;
    }

    public void QuitToStart()
    {
        if (AudioManager.Instance)
        {
            AudioManager.Instance.PlaySound("ButtonPress");
            AudioManager.Instance.StopSound("StartGame");
        }
        Time.timeScale = 1;
        if (playerMove)
        {
            Destroy(playerMove.gameObject);
        }
        CameraFollow cam = FindObjectOfType<CameraFollow>();
        if (cam)
        {
            Destroy(cam.gameObject);
        }

        if (GameController.Instance)
        {
            GameController gc = GameController.Instance;
            gc.playerIndex = 0;
            gc.isGameOver = false;
            gc.score = 0;
        }
        Destroy(gameObject);
        SceneManager.LoadScene("StartMenu");
    }

    public void GameOverPanel(string txt)
    {
        if (panel_GameOver && gameOverTxt)
        {
            Time.timeScale = 0;
            panel_GameOver.SetActive(true);
            gameOverTxt.text = txt;
            txt_GameOverScore.text = "Score : " + txt_Score.text;
        }
    }

    public void EndLevelPanel(bool value)
    {
        if (value)
        {
            Time.timeScale = 0;
            panel_EndLevel.SetActive(value);
        }
        else
        {
            Time.timeScale = 1;
            panel_EndLevel.SetActive(value);
        }
    }

    public void NextLevel()
    {
        panel_EndLevel.SetActive(false);
        if (PlayerMovement.Instance)
        {
            PlayerMovement.Instance.rb.bodyType = RigidbodyType2D.Static;
        }
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
