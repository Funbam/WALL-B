using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class pauseGame : MonoBehaviour
{
    public GameObject pause;

    public void togglePause()
    {
        if (pause.activeInHierarchy)
        {
            pause.SetActive(false);
            Time.timeScale = 1f;
        }
        else
        {
            showPause();
            Time.timeScale = 0f;
        }
    }


    public void showPause()
    {
        pause.SetActive(true);
    }

    public void quitGame()
    {
        Application.Quit();
    }

}
