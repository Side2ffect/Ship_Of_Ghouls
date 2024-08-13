using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class GhostAI : MonoBehaviour
{

    [SerializeField] Transform[] wayPointArray;

   

    [SerializeField] float delay;

    [SerializeField] bool stationaryGhost;
   

   [SerializeField] private bool reached;
    private NavMeshAgent navMeshAgent;
    private bool incremented;
   [SerializeField] private int wayPointArrayIndex = 0;

    [SerializeField] Animator ghostAnimator;


   [SerializeField] private bool inFOV = false;




    public NavMeshAgent GetNavMeshAgent()
    {
        return navMeshAgent;
    }
    public bool GetIfInFov()
    {
        return inFOV;
    }


    public void SetIfInFOV(bool value)
    {

        inFOV = value;
    }

    private GhostThreatAssesmentSystem ghostThreatAssesmentSystem;
    void Start()
    {
        navMeshAgent = GetComponentInParent<NavMeshAgent>();
        ghostThreatAssesmentSystem = GetComponent<GhostThreatAssesmentSystem>();
    }

    // Update is called once per frame
    void Update()
    {



        int priorityOfThreat = ghostThreatAssesmentSystem.GetCurrentPriority();

        //if (inFOV)
        //{
        //    StopAllCoroutines();    
        //}

        if (!inFOV)
        {
            if (priorityOfThreat==0 && !stationaryGhost)
            {
                ghostThreatAssesmentSystem.SetTarget(wayPointArray[wayPointArrayIndex], 0);

                MoveToTarget(ghostThreatAssesmentSystem.GetCurrentTarget());



            }


            if (priorityOfThreat == 1)
            {
                MoveToTarget(ghostThreatAssesmentSystem.GetCurrentTarget());
            }


            if (priorityOfThreat == 2)
            {
                navMeshAgent.Stop();
                ghostAnimator.SetTrigger("Stunned");
                StartCoroutine(Delay(delay));
                
            }

        }


        if (priorityOfThreat == 3)
        {
            MoveToTarget(ghostThreatAssesmentSystem.GetCurrentTarget());
        }














    }


    private void MoveToTarget(Transform position)
    {
       
      
        if (!reached)
        {
            incremented = false;

            navMeshAgent.destination = position.position;
           
        }

        

        if (ghostThreatAssesmentSystem.GetCurrentPriority() == 0)
        {
            if (!navMeshAgent.pathPending)
            {
                if (navMeshAgent.remainingDistance <= navMeshAgent.stoppingDistance && !incremented)
                {
                    reached = true;
                    IncrementWayPoint();
                }
            }

           

        }

        else if (ghostThreatAssesmentSystem.GetCurrentPriority()!=3)
        {
            if (!navMeshAgent.pathPending)
            {
                if (navMeshAgent.remainingDistance <= navMeshAgent.stoppingDistance)
                {
                    reached = true;

                   
                    StartCoroutine(Delay(delay));
                    

                   
                }
            }
        }

        else
        {
            navMeshAgent.stoppingDistance = 2.75f;
        }


    }

    private void IncrementWayPoint()
    {
        if (wayPointArrayIndex >= wayPointArray.Length - 1)
        {
            wayPointArrayIndex = 0;
        }

        else
        {
            wayPointArrayIndex++;
        }

        


        incremented = true;
        reached = false;
    }


    IEnumerator Delay(float seconds)
    {

       
       
       
            yield return new WaitForSeconds(seconds);

        ghostAnimator.ResetTrigger("Stunned");
            reached = false;

            if (ghostThreatAssesmentSystem.GetCurrentTarget() != null)
            {
                if (ghostThreatAssesmentSystem.GetCurrentTarget().gameObject.GetComponent<ThrowCrate>() != null)
                    ghostThreatAssesmentSystem.GetCurrentTarget().gameObject.GetComponent<ThrowCrate>().Reset();
            }
            ghostThreatAssesmentSystem.ResetThreat();

            if (navMeshAgent != null)
            {
                navMeshAgent.Resume();
            }


        

       
      
    }
}
