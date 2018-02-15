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
    public Text scoreText;
    public Text highScore1;
    public Text highScore2;
    public Text diamondCountText;

    public string ANDROID_RATE_URL = "market://details?id=com.JeomarInteractive.Zaggy_Ball";
    //public string ANDROID_RATE_NOADS_URL = "market://details?id=com.JeomarInteractive.Zaggy_BallNoAds";

    public string ANDROID_PURCHASE_NOADS_URL = "market://details?id=com.JeomarInteractive.Zaggy_BallNoAds";

    public static UIManager instance;

    // Private Variables
    private int score = 0;
    private int diamondCount = 0;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }

        diamondCountText.text = "x " + diamondCount;
    }

    

    public void GameStart()
    {
        tapToPlayText.SetActive(false);
        titlePanel.GetComponent<Animator>().Play("titlePanelSlideUp");
    }

    public void UpdateScore()
    {
        score += 1;
        scoreText.text = "Score: " + score;
        highScore1.text = PlayerPrefs.GetInt("score").ToString();

    }

    public void DiamondCounter()
    {
        diamondCount += 1;
        diamondCountText.text = "X " + diamondCount;
    }

    public void GameOver()
    {
        scoreText.text = PlayerPrefs.GetInt("score").ToString();
        scoreText.enabled = false;
        highScore2.text = PlayerPrefs.GetInt("highScore").ToString();
        titlePanel.GetComponent<Animator>().Play("titlePanelSlideDown");
        gameOverPanel.SetActive(true);
    }

    public void ShowLeaderBoard()
    {
        LeaderBoardManager.instance.ShowLeaderBoard();
    }

    public void RateUs()
    {
#if UNITY_ANDROID
        Application.OpenURL(ANDROID_RATE_URL);
#endif

#if UNITY_ANDROID
        //Application.OpenURL(ANDROID_RATE_NOADS_URL);
#endif
    }

    public void BuyNoAds()
    {
#if UNITY_ANDROID
        Application.OpenURL(ANDROID_PURCHASE_NOADS_URL);
#endif

    }

    public void Reset()
    {
        SceneManager.LoadScene(0);
    }
}
