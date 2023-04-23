using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Distortion : MonoBehaviour
{
    public float distortionPercent;
    private float initialDistance;
    [SerializeField] private Transform Player;
    [SerializeField] private Transform FinalGoal;

    private void Start()
    {
        initialDistance = Vector3.Distance(Player.position, FinalGoal.position);
    }

    // Update is called once per frame
    void Update()
    {
        distortionPercent = 1 - (initialDistance - Vector3.Distance(Player.position, FinalGoal.position)/initialDistance);
    }
}
