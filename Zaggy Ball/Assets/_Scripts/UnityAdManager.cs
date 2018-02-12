using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;


public class UnityAdManager : MonoBehaviour 
{

    static int loadcount = 0;

    public static UnityAdManager instance;


    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    // Use this for initialization

    void Start () 
	{
        if (loadcount % 3 == 0)
        {
            ShowAd();
        }

        loadcount++;
	}

	public void ShowAd()
    {
        if (Advertisement.IsReady())
        {
            Advertisement.Show();
        }
    }
	
	// Update is called once per frame
	
	void Update () 
	{
		
			
	}

    //public void ShowAd()
    //{

    //    if (PlayerPrefs.HasKey("Adcount"))
    //    {
    //        if (PlayerPrefs.GetInt("Adcount") >= 3)
    //        {
    //            if (Advertisement.IsReady("video"))
    //            {
    //                Advertisement.Show("video");
    //            }
    //            PlayerPrefs.SetInt("Adcount", 0);
    //        }
    //        else
    //        {
    //            PlayerPrefs.SetInt("Adcount", PlayerPrefs.GetInt("Adcount") + 1);
    //        }
    //    }
    //    else
    //    {
    //        PlayerPrefs.SetInt("Adcount", 0);
    //    }
    //}


}
