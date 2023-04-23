using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class mainMenu : MonoBehaviour
{
    [Header("Cinemachine Cam")]
    [SerializeField] private CinemachineVirtualCamera main;
    [SerializeField] private CinemachineVirtualCamera howToPlay;
    [SerializeField] private CinemachineVirtualCamera credits;

    [Header("UI")]
    [SerializeField] private GameObject mainUI;
    [SerializeField] private GameObject howToPlayUI;
    [SerializeField] private GameObject creditsUI;

    private void Start()
    {
        mainMenuCam();
    }

    public void howToPlayCam()
    {
        howToPlay.Priority = 100;
        credits.Priority = -1;
        main.Priority = -1;
        mainUI.SetActive(false);
        howToPlayUI.SetActive(true);
        creditsUI.SetActive(false);
    }

    public void loadGame()
    {
        SceneManager.LoadScene("Audio Cutscene");
    }

    public void mainMenuCam()
    {
        howToPlay.Priority = -1;
        credits.Priority = -1;
        main.Priority = 100;
        mainUI.SetActive(true);
        howToPlayUI.SetActive(false);
        creditsUI.SetActive(false);
    }

    public void creditsCam()
    {
        howToPlay.Priority = -1;
        credits.Priority = 100;
        main.Priority = -1;
        mainUI.SetActive(false);
        howToPlayUI.SetActive(false);
        creditsUI.SetActive(true);
    }

    public void quitGame()
    {
        Application.Quit();
    }
}
