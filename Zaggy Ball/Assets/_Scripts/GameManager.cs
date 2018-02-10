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
        gameOver = false;
			
	}

	
	
	// Update is called once per frame
	
	void Update () 
	{
		
			
	}

    public void StartGame()
    {
        UIManager.instance.GameStart();
        GameObject.Find("PlatformSpawner").GetComponent<PlatformGenerater>().StartPlatformSpawn();
        ScoreHandler.instance.TrackScore();
    }

    public void GameOver()
    {
        ScoreHandler.instance.OnGameOver();
        UIManager.instance.GameOver();
        gameOver = true;
    }


}
