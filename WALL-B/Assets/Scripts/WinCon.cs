using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class WinCon : MonoBehaviour
{
    [SerializeField] Timer timer;
    [SerializeField] ScoreManager scoreManager;
    public UnityEvent<bool> togglePanelEvent;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            scoreManager.SetScore(timer.GetTimeScore());
            togglePanelEvent.Invoke(true);
        }
    }
}
