using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostThreatAssesmentSystem : MonoBehaviour
{
   [SerializeField] private Transform currentTarget;

    private int currentPriority = 0;




    public Transform GetCurrentTarget()
    {
        return currentTarget;
    }


    public int GetCurrentPriority()
    {
        return currentPriority;
    }

    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }



   public void SetTarget(Transform obj , int priority)
   {
      
        if(currentTarget == null || currentPriority <= priority )
        {
            currentTarget = obj;

            currentPriority = priority;
        }

        
   }


    public void ResetThreat()
    {
        currentPriority = 0;
        currentTarget = null;
    }
}
