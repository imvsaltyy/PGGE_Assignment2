using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Lobby : MonoBehaviour
{

    public void OnClickSinglePlayer()
    {
        Debug.Log("clicked singleplayer room");
        //play the audio clip from the method for that instance
        AudioManager.Instance.PlayAudio();
        Debug.Log("loading singleplayer game");
        SceneManager.LoadScene("SinglePlayer");
    }

    public void OnClickMultiPlayer()
    {
        Debug.Log("clicked multiplayer room");
        //play the audio clip from the method for that instance
        AudioManager.Instance.PlayAudio();
        Debug.Log("loading multiplayer game");
        SceneManager.LoadScene("Multiplayer_Launcher");
        
    }

}
