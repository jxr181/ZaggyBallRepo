using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class BallController : MonoBehaviour 
{
    // Public Variables
    [SerializeField] float speed = 10f;
    public GameObject collectedPart;


    // Private Variables
    Rigidbody rigidbody;
    private bool started;
    private bool gameOver;

    void Awake()
    {
        rigidbody = GetComponent<Rigidbody>();
        
    }

    void Start () 
	{
        started = false;
        gameOver = false;
    }

	
	
	// Update is called once per frame
	
	void Update () 
	{
        if (!started)
        {
            if (Input.GetMouseButtonDown(0) && !gameOver)
            {
                rigidbody.velocity = new Vector3(speed, 0, 0);
                started = true;
                
                GameManager.instance.StartGame();
            } 
        }

        if (!Physics.Raycast(rigidbody.position, Vector3.down, 1f))
        {
            Physics.Raycast(rigidbody.position, Vector3.down, 1f);
            gameOver = true;
            rigidbody.velocity = new Vector3(0, -25f, 0);

            Camera.main.GetComponent<CameraFollow>().go = true;

            GameManager.instance.GameOver();
        }

        if (Input.GetMouseButtonDown(0) && !gameOver)
        {
            SwitchDirection();
            ScoreHandler.instance.TrackScore();
            UIManager.instance.UpdateScore();
        }
	}

    void SwitchDirection()
    {
        if (rigidbody.velocity.z > 0)
        {
            rigidbody.velocity = new Vector3(speed, 0, 0);
        }
        else if (rigidbody.velocity.x > 0)
        {
            rigidbody.velocity = new Vector3(0, 0, speed);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Diamond")
        {
            GameObject part = Instantiate(collectedPart, transform.position, Quaternion.identity) as GameObject;
            Destroy(other.gameObject);
            Destroy(part, 1f);
        }
    }
}
