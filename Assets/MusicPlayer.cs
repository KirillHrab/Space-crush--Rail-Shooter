using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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
    // Start is called before the first frame update
    void Start()
    {
        Invoke("LoadFirstScene", 2f);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
    void LoadFirstScene()
    {
        SceneManager.LoadScene(1);
    }
    
}
