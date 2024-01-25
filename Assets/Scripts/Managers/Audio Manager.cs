using Photon.Pun.UtilityScripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    //make it a singleton
    public static AudioManager Instance;

    //variables to hold different audio clips
    public AudioClip audioClip;
    public AudioClip backAudioClip;

    //reference to the audiosource component
    private AudioSource audioSource;

    //called when script instance is loaded
    private void Awake()
    {
        //check for no existing instance of the audio manager
        if (Instance == null)
        {
            //set the current instance to this instance (singleton)
            Instance = this;
            //audio manager will not be destroy when changing from scene to scene
            DontDestroyOnLoad(gameObject);
            Debug.Log("audio manager created");
        }
        else
        {
            //there is an existing instance in the scene, destroy the newly duplicated audio manager
            Destroy(gameObject);
            Debug.Log("destroy duplicated audio manager");
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        // get audio source component
        audioSource = GetComponent<AudioSource>();
    }

    //for the back button
    public void PlayBackAudio()
    {
        // check if the back audioclip is not null
        if (backAudioClip != null)
        {
            //play the back audio clip, use playoneshot for short sound effects
            audioSource.PlayOneShot(backAudioClip);
            Debug.Log("play back audio clip");
        }
    }
    
    public void PlayAudio()
    {
        // check if the audioclip is not null
        if(audioClip != null)
        {
            // play the audio clip
            audioSource.PlayOneShot(audioClip);
            Debug.Log("play");
        }
    }
    
}

