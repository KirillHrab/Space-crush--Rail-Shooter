using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionHandler : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        StartDeath();
    }
    private void StartDeath()
    {
        
        print("Player Death");
        SendMessage("OnPlayerDeath");

    }
    
}
