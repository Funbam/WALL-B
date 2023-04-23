using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mainMenu : MonoBehaviour
{
    [SerializeField] private CinemachineVirtualCamera main;
    [SerializeField] private CinemachineVirtualCamera howToPlay;
    [SerializeField] private CinemachineVirtualCamera credits;

    private void Start()
    {
        mainMenuCam();
    }

    public void howToPlayCam()
    {
        howToPlay.Priority = 100;
        credits.Priority = -1;
        main.Priority = -1;
    }

    public void mainMenuCam()
    {
        howToPlay.Priority = -1;
        credits.Priority = -1;
        main.Priority = 100;
    }

    public void creditsCam()
    {
        howToPlay.Priority = -1;
        credits.Priority = 100;
        main.Priority = -1;
    }

    public void quitGame()
    {
        Application.Quit();
    }
}
