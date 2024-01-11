using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    private MenuSounds sounds;

    // Start is called before the first frame update
    void Start()
    {
        sounds = GetComponentInParent<MenuSounds>();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnClickSinglePlayer()
    {
        //Debug.Log("Loading singleplayer game");
        sounds.playClick();
        SceneManager.LoadScene("SinglePlayer");
    }

    public void OnClickMultiPlayer()
    {
        //Debug.Log("Loading multiplayer game");
        sounds.playClick();
        SceneManager.LoadScene("Multiplayer_Launcher");
    }

}
