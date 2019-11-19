using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class go_to_scena : MonoBehaviour
{
  
    public void ChangeScene(string sceneName)
    {
        Application.LoadLevel(sceneName);
    }

}
