using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;


public class BallController : MonoBehaviour 
{
    // Public Variables
    [SerializeField] float speed = 10f;
    public GameObject collectedPart;

    // Private Variables
    Rigidbody rigidbody;
    private bool started;
    private bool gameOver;
    private AudioSource pickUp;

    void Awake()
    {
        rigidbody = GetComponent<Rigidbody>();
        pickUp = GetComponent<AudioSource>();
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

            if (Input.GetMouseButtonDown(0) && !gameOver)
            {

                SwitchDirection();
                ScoreHandler.instance.TrackScore();
                UIManager.instance.UpdateScore();
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
            pickUp.Play();
            GameObject part = Instantiate(collectedPart, transform.position, Quaternion.identity) as GameObject;
            Destroy(other.gameObject);
            Destroy(part, 1f);
        }
    }
}
