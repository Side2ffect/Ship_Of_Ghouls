using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostWayPointTraversal : MonoBehaviour
{
    [SerializeField] Transform[] wayPointArray;

    [SerializeField] float moveSpeed;
     float threshold;

    private Transform currentWayPoint;
    private bool wayPointReached;

    private GhostThreatAssesmentSystem ghostThreatAssesmentSystem;

    private int wayPointArrayIndex = 0;


    private bool incremented = false;
    public bool GetWayPointReached()
    {
        return wayPointReached;
    }

    public Transform GetCurrentWayPoint()
    {
        return currentWayPoint;
    }

   
    void Start()
    {

        ghostThreatAssesmentSystem = GetComponent<GhostThreatAssesmentSystem>();
        if(currentWayPoint == null)
        {
            currentWayPoint = wayPointArray[wayPointArrayIndex];
        }
    }

    // Update is called once per frame
    void Update()
    {

       

        if (ghostThreatAssesmentSystem.GetCurrentPriority()==0)
        {
            ghostThreatAssesmentSystem.SetTarget(wayPointArray[wayPointArrayIndex], 0);
            MoveToNextWayPoint();

        }


    }


    private void MoveToNextWayPoint()
    {
        if (!wayPointReached)
        {
            incremented = false;
            transform.position = Vector3.MoveTowards(transform.position, currentWayPoint.position, moveSpeed * Time.deltaTime);
        }

        if ((Vector3.Distance(transform.position, currentWayPoint.position) <= threshold) && !incremented)
        {
            wayPointReached = true;
            IncrementWayPoint();
        }
       

    }


    private void IncrementWayPoint()
    {
       if(wayPointArrayIndex >= wayPointArray.Length-1)
       {
            wayPointArrayIndex = 0;
       }

        else
        {
            wayPointArrayIndex++;
        }

        currentWayPoint = wayPointArray[wayPointArrayIndex];
        incremented = true;
        wayPointReached = false;
    }
}
