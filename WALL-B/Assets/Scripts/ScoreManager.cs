using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Events;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance;
    private int rawScore = 0;
    [SerializeField] TextMeshProUGUI scoreText;
    [SerializeField] TMP_InputField inputUsername;

    public UnityEvent<string, int> submitScoreEvent;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
    }

    public void SetScore(int score)
    {
        rawScore = score;

        float min = Mathf.FloorToInt(rawScore / 60);
        float sec = Mathf.FloorToInt(rawScore % 60);

        scoreText.text = string.Format("{0:00} : {1:00}", min, sec);
    }

    public void SubmitScore()
    {
        Debug.Log("1");
        submitScoreEvent.Invoke(inputUsername.text, rawScore);
        Debug.Log("here");
    }
}
