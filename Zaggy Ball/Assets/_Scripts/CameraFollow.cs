using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CameraFollow : MonoBehaviour 
{
    // Public Variables
    public GameObject ball;
    public float lerpRate;
    public bool go;

    // Private Variables
    Vector3 offset;

	// Use this for initialization
	
	void Start () 
	{
        offset = ball.transform.position - transform.position;
        go = false;
	}

	
	
	// Update is called once per frame
	
	void Update () 
	{
        if (!go)
        {
            Follow(); 
        }
			
	}

    void Follow()
    {
        Vector3 pos = transform.position;
        Vector3 targetPos = ball.transform.position - offset;

        pos = Vector3.Lerp(pos, targetPos, lerpRate * Time.deltaTime);
        transform.position = pos;
        
    }

}
