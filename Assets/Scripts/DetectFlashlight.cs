using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectFlashlight : MonoBehaviour
{
    public bool isStunned = false;

    private bool hasBeenStunned = false;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    void OnTriggerStay(Collider col)
    {
        
        if (col.gameObject.CompareTag("FlashLight") && isStunned  &&  !hasBeenStunned)
        {
            GetComponentInParent<GhostThreatAssesmentSystem>().SetTarget(col.gameObject.transform, 2);
            hasBeenStunned = true;
        }
    }


}
