using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;

public class FOVDetection : MonoBehaviour
{
    [SerializeField] LayerMask layerMask;

    [SerializeField] DetectFlashlight detectFlashlight;


    
   
    private RaycastHit rhit;

    bool ishit = false;
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Transform t = GetComponentInParent<GhostAI>().GetNavMeshAgent().transform;
        ishit = false;
        if(Physics.Raycast(t.position,t.forward,out rhit, 50f, layerMask))
        {
           if(rhit.collider.CompareTag("Player"))
            ishit = true;
        }
      
        
    }


    private void OnTriggerStay(Collider other)
    {
       

        if(other.CompareTag("Player") && ishit)
        {
            GetComponentInParent<GhostAI>().SetIfInFOV(true);
            GetComponentInParent<GhostThreatAssesmentSystem>().SetTarget(other.gameObject.transform, 3);
        }


       


    }

    



}
