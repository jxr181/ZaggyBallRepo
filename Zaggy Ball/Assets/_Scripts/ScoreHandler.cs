using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ScoreHandler : MonoBehaviour 
{
    // Public Variables
    public int score;
    public int highScore;

    public static ScoreHandler instance;

	// Use this for initialization
	
	void Awake () 
	{
        if (instance == null)
        {
            instance = this;
        }
	}

    void Start()
    {
        score = 0;
    }

    public void TrackScore()
    {
        score += 1;
        PlayerPrefs.SetInt("score", score);
    }

    public void OnGameOver()
    {

        if (PlayerPrefs.HasKey("highScore"))
        {
            if (score > PlayerPrefs.GetInt("highScore"))
            {
                PlayerPrefs.SetInt("highScore", score); 
            }
        }
        else
        {
            PlayerPrefs.SetInt("highScore", score);
        }
    }


}
