using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GooglePlayGames;
using UnityEngine.SocialPlatforms;


public class LeaderBoardManager : MonoBehaviour
{

    public static LeaderBoardManager instance;


    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
    }


    // Use this for initialization

    void Start()
    {
        PlayGamesPlatform.Activate();
        Login();

    }



    // Update is called once per frame

    void Update()
    {


    }

    public void Login()
    {
        Social.localUser.Authenticate((bool success) => 
        {

        });
    }

    public void AddScoreToLeaderBoard()
    {
        Social.ReportScore(ScoreHandler.instance.score, LeaderBoards.leaderboard_top_players, (bool success) => { });
    }

    public void ShowLeaderBoard()
    {
        if (Social.localUser.authenticated)
        {
            PlayGamesPlatform.Instance.ShowLeaderboardUI(LeaderBoards.leaderboard_top_players); 
        }
        else
        {
            Login();
        }
    }
}
