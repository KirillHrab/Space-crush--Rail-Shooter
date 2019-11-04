using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour
{
    [SerializeField] GameObject deathFX;
    private void OnTriggerEnter(Collider other)
    {
        StartDeath();
    }
    private void StartDeath()
    {
        
        print("Player Death");
        SendMessage("OnPlayerDeath");
        deathTrigger();

    }
    void deathTrigger()
    {
        Invoke("LoadFirstLevel", 2f);
        deathFX.SetActive(true);
    }
    void LoadFirstLevel()
    {
        SceneManager.LoadScene(1);
    }
}
