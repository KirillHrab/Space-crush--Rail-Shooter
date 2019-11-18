using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript1 : MonoBehaviour
{
    // Start is called before the first frame update
    void Awake()
    {
        GameObject[] objct = GameObject.FindGameObjectsWithTag("Music");
        if (objct.Length > 1)
            Destroy(this.gameObject);
        //оло
        DontDestroyOnLoad(this.gameObject);
    }
}
