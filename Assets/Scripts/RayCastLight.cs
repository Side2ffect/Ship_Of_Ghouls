using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayCastLight : MonoBehaviour
{
    public  LayerMask layerMask;

    [SerializeField] DetectFlashlight detectFlashlight;

    private RaycastHit rhit;
    void Start()
    {
    }

    // Update is called once per frame
    void FixedUpdate()
    {




        Debug.DrawRay(transform.position, transform.forward * 10f, Color.cyan);
        if (Physics.Raycast(transform.position, transform.forward, out rhit,10f, layerMask))
        {
           
           
            if (rhit.collider.tag== "Ghost")
            {
                if (detectFlashlight != null)
                {
                    detectFlashlight.isStunned = true;
                }
            }
        }
       
        
           
        
    }
}
