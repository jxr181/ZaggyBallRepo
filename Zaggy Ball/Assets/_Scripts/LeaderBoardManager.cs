using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GooglePlayGames;
using UnityEngine.SocialPlatforms;


public class LeaderBoardManager : MonoBehaviour
{




    // Use this for initialization

    void Start()
    {


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
        // Social.ShowLeaderboardUI();
        PlayGamesPlatform.Instance.ShowLeaderboardUI(LeaderBoards.leaderboard_top_players);
    }
}
