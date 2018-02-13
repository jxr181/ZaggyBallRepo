using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class AudioManager : MonoBehaviour 
{

    public static AudioManager instance;

    public AudioSource audioSource;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        audioSource = GetComponent<AudioSource>();
    }


    public void MuteAudio()
    {
        audioSource.mute = !audioSource.mute;
    }
}
