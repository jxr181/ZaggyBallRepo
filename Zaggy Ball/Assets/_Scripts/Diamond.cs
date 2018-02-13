using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Diamond : MonoBehaviour
{
    // Variables
    public GameObject collectedPart;
    

    // private variables

    private void Awake()
    {
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Ball")
        {
            AudioManager.instance.audioSource.Play();
            UIManager.instance.DiamondCounter();
            GameObject part = Instantiate(collectedPart, transform.position, Quaternion.identity) as GameObject;
            Destroy(gameObject);
            Destroy(part, 1f);
        }
    }
}
