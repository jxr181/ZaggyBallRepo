using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class UIManager : MonoBehaviour 
{
    // Public Variables
    public GameObject titlePanel;
    public GameObject gameOverPanel;
    public GameObject tapToPlayText;
    public Toggle muteToggle;
    public Text scoreText;
    public Text highScore1;
    public Text highScore2;


    public static UIManager instance;

    // Private Variables
    private int score = 0;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    void Start()
    {
        
    }

    public void GameStart()
    {
        tapToPlayText.SetActive(false);
        titlePanel.GetComponent<Animator>().Play("titlePanelSlideUp");
    }

    public void UpdateScore()
    {
        score += 1;
        scoreText.text = score.ToString();
        highScore1.text = PlayerPrefs.GetInt("score").ToString();

    }

    public void GameOver()
    {
        scoreText.text = PlayerPrefs.GetInt("score").ToString();
        highScore2.text = PlayerPrefs.GetInt("highScore").ToString();
        gameOverPanel.SetActive(true);
    }

    public void MuteAudio()
    {
        AudioListener.pause = !AudioListener.pause;
    }

    public void Reset()
    {
        SceneManager.LoadScene(0);
    }
}
