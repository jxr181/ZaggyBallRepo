using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GameManager : MonoBehaviour 
{
    // Public VAriables
    public bool gameOver;

    public static GameManager instance;


    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    // Use this for initialization

    void Start () 
	{
			
	}

	
	
	// Update is called once per frame
	
	void Update () 
	{
		
			
	}

    public void StartGame()
    {
        gameOver = false;
        UIManager.instance.GameStart();
        GameObject.Find("PlatformSpawner").GetComponent<PlatformGenerater>().StartPlatformSpawn();
        ScoreHandler.instance.TrackScore();
    }

    public void GameOver()
    {
        UIManager.instance.GameOver();
        ScoreHandler.instance.OnGameOver();
        LeaderBoardManager.instance.AddScoreToLeaderBoard();
        gameOver = true;
        //UnityAdManager.instance.ShowAd();
    }


}
