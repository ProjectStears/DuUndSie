using System;
using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class MenuHandler : MonoBehaviour {

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {

            if (SceneManager.GetActiveScene().name == "Default")
            {
                SceneManager.LoadScene("Start");
            }

            if (SceneManager.GetActiveScene().name == "Start")
            {
                QuitGame();
            }
        }
    }


    public void StartGame()
    {
        SceneManager.LoadScene("Default");
    }

    public void QuitGame()
    {
        Debug.Log("Quitting!");
        Application.Quit();
    }

    public void ShowAbout()
    {
        //switch to About canvas
    }
    public void ShowStart()
    {
        //switch to Start canvas
    }


}
