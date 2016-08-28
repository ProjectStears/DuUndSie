using System;
using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class MenuHandler : MonoBehaviour {

    public void StartGame()
    {
        SceneManager.LoadScene("Default");
    }

    public void QuitGame()
    {
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
