using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CollisionHandler : MonoBehaviour 
{

	// Use this for initialization
	
	void Start () 
	{
		
			
	}

	
	
	// Update is called once per frame
	
	void Update () 
	{
			
	}

    

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Ball") 
        {
            Invoke("FallDown", 1f);
        }
    }

    void FallDown()
    {
        GetComponentInParent<Rigidbody>().useGravity = true;
        GetComponentInParent<Rigidbody>().isKinematic = false;
        Destroy(transform.parent.gameObject, 2f);
    }
}
