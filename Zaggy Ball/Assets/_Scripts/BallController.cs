using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;


public class BallController : MonoBehaviour 
{
    // Public Variables
    [SerializeField] float speed = 10f;

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
        StartGame();
    }

    // Starts the game when the screen is tapped the first time and if the game hasn't already started
    public void StartGame()
    {
        if (Application.platform == RuntimePlatform.Android)
        {
            if (!started)
            {
                if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
                {
                    int pointerID = Input.GetTouch(0).fingerId;

                    if (!EventSystem.current.IsPointerOverGameObject(pointerID))
                    {
                        rigidbody.velocity = new Vector3(speed, 0, 0);
                        started = true;

                        GameManager.instance.StartGame();
                    }
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

            if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
            {
                int pointerID = Input.GetTouch(0).fingerId;

                if (!EventSystem.current.IsPointerOverGameObject(pointerID))
                {

                    SwitchDirection();
                    ScoreHandler.instance.TrackScore();
                    UIManager.instance.UpdateScore(); 
                }
            } 
        }

        else
        {
            if (!started)
            {
                if (Input.GetMouseButtonDown(0) && !gameOver)
                {

                    if (!EventSystem.current.IsPointerOverGameObject())
                    {
                        rigidbody.velocity = new Vector3(speed, 0, 0);
                        started = true;

                        GameManager.instance.StartGame();
                    }
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
                if (!EventSystem.current.IsPointerOverGameObject())
                {
                    SwitchDirection();
                    ScoreHandler.instance.TrackScore();
                    UIManager.instance.UpdateScore(); 
                }
            }
        }
    }

    // Changes the direction of the ball along the X and Z axis
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

    
}
