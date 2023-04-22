using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoboSchmoovin : MonoBehaviour
{
    [SerializeField] private List<Transform> waypoints;
    [SerializeField] private Transform player;
    [SerializeField] private float distanceThreshold;
    private int waypointIndex;
    [SerializeField] private float moveSpeed;

    private enum States
    {
        moving,
        waiting
    }

    private States currentState = States.waiting;

    private void Start()
    {
        transform.position = waypoints[0].position;
    }

    private void Update()
    {
        if (Vector3.Distance(transform.position, player.position) <= distanceThreshold)
        {
            if(currentState == States.waiting && waypointIndex < waypoints.Count-1)
            {
                waypointIndex++;
                currentState = States.moving;
            }
        }

        if(currentState == States.moving)
        {
            StartCoroutine(Move(waypoints[waypointIndex]));
        }


    }

    private IEnumerator Move(Transform destination)
    {
        //Move platform over time
        while (this.transform.position != destination.transform.position)
        {
            this.transform.position = Vector3.MoveTowards(this.transform.position, destination.transform.position, moveSpeed * Time.deltaTime);
            yield return null;
        }
        currentState = States.waiting;
    }
}