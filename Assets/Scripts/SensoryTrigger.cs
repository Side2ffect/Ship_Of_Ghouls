using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SensoryTrigger : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {


        if (!GetComponentInParent<GhostAI>().GetIfInFov())
        {

            if (other.gameObject.CompareTag("Crate"))
            {

               
                if (other.gameObject.GetComponent<ThrowCrate>().thrown && other.gameObject.GetComponent<Rigidbody>().velocity.magnitude >= 0.5f)
                {
                    GetComponentInParent<GhostThreatAssesmentSystem>().SetTarget(other.gameObject.transform, 1);

                }
            }

        }  
    }
}
