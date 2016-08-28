using System;
using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class MenuHandler : MonoBehaviour
{

    public RectTransform StartCanvas;
    public RectTransform AboutCanvas;

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
        if (AboutCanvas != null && StartCanvas != null)
        {
            AboutCanvas.gameObject.SetActive(true);
            StartCanvas.gameObject.SetActive(false);
        }

    }
    public void ShowStart()
    {
        if (AboutCanvas != null && StartCanvas != null)
        {
            AboutCanvas.gameObject.SetActive(false);
            StartCanvas.gameObject.SetActive(true);
        }
    }


}
