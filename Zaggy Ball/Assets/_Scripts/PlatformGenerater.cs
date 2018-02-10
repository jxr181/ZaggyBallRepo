﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlatformGenerater : MonoBehaviour 
{
    // Public Variables
    public GameObject platForm;
    public GameObject diamond;
    public bool gameOver;

    // Private Variables
    private Vector3 lastPos;
    private float size;

    // Use this for initialization

    void Start () 
	{
        lastPos = platForm.transform.position;
        size = platForm.transform.localScale.x;

        for (int i = 0; i < 20; i++)
        {
            SpawnPlatforms();
        }

        
	}

	public void StartPlatformSpawn()
    {
        InvokeRepeating("SpawnPlatforms", 0.1f, 0.2f);
    }
	
	// Update is called once per frame
	
	void Update () 
	{
        if (GameManager.instance.gameOver == true)
        {
            CancelInvoke("SpawnPlatforms");
        }

    }

    void SpawnPlatforms()
    {
        

        int rand = Random.Range(0, 7);

        if (rand < 3)
        {
            SpawnX();
        }

        else if (rand >= 3)
        {
            SpawnZ();
        }


    }

    void SpawnX()
    {
        Vector3 pos = lastPos;
        pos.x += size;
        lastPos = pos;
        Instantiate(platForm, pos, Quaternion.identity);

        int rand = Random.Range(0, 4);

        if (rand < 1)
        {
            Instantiate(diamond, new Vector3(pos.x, pos.y + 3, pos.z), diamond.transform.rotation);
        }
        
    }

    void SpawnZ()
    {
        Vector3 pos = lastPos;
        pos.z += size;
        lastPos = pos;
        Instantiate(platForm, pos, Quaternion.identity);

        int rand = Random.Range(0, 4);

        if (rand < 1)
        {
            Instantiate(diamond, new Vector3(pos.x, pos.y + 3, pos.z), diamond.transform.rotation);
        }
    }

}
