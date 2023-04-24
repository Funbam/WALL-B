using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Distortion : MonoBehaviour
{
    public float distortionPercent;
    private float initialDistance;
    [SerializeField] private Transform FinalGoal;

    private void Start()
    {
        GameObject Player = GameObject.FindGameObjectWithTag("Player");
        if (Player)
        {
            initialDistance = Vector3.Distance(Player.transform.position, FinalGoal.position);
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        GameObject Player = GameObject.FindGameObjectWithTag("Player");
        if (Player)
        {
            distortionPercent = ((initialDistance - Vector3.Distance(Player.transform.position, FinalGoal.position)) / initialDistance);
        }
    }
}
