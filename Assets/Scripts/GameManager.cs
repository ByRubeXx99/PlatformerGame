using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
    }
    private void OnEnable()
    {
        DeathTrigger.OnDeath += LoadEnding;
    }

    private void OnDisable()
    {
        DeathTrigger.OnDeath -= LoadEnding;
    }

    private void LoadEnding()
    {
        SceneManager.LoadScene("Ending");
    }
}
