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
