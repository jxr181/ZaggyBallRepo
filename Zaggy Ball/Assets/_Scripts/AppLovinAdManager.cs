using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class AppLovinAdManager : MonoBehaviour 
{

    public static AppLovinAdManager instance;



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
        AppLovin.InitializeSdk();
        AppLovin.PreloadInterstitial();
	}

	
	
	// Update is called once per frame
	
	void Update () 
	{
		
			
	}

    public void ShowInterstitialAd()
    {
        if (AppLovin.HasPreloadedInterstitial())
        {
            AppLovin.ShowInterstitial(); 
        }
    }
}
