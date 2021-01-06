using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicPlayer : MonoBehaviour
{
    // Start is called before the first frame update

    private void Awake()
    {
       int numMusicPlayers =  FindObjectsOfType<MusicPlayer>().Length;
       if(numMusicPlayers > 1)
        {
            Destroy(this.gameObject);
        }
       else
        {
            DontDestroyOnLoad(this.gameObject);
        }
        //Singleton pattern:
        //if more than one music player in scene
            //Destroy ourselves
        //Else
       
    }

}

