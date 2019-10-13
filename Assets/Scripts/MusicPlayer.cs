using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class MusicPlayer : MonoBehaviour
{
    //Loop our music 
    void Awake()
    {
        GameObject[] objct = GameObject.FindGameObjectsWithTag("Music");
        if (objct.Length > 1)
            Destroy(this.gameObject);

        DontDestroyOnLoad(this.gameObject);
    }
    
    
}
