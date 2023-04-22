using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    [SerializeField] TMP_Text timerText;
    [SerializeField] private bool timerRunning;
    private float timePassed;
    // Start is called before the first frame update

    private void Awake()
    {
        
    }

    private void Start()
    {
        timerRunning = true;
    }

    private void Update()
    {
        if (timerRunning)
        {
            timePassed += Time.deltaTime;

            float min = Mathf.FloorToInt(timePassed / 60);
            float sec = Mathf.FloorToInt(timePassed % 60);

            timerText.text = string.Format("{0:00} : {1:00}", min, sec);
        }
    }

    public int GetTimeScore()
    {
        return (int)timePassed;
    }
}
