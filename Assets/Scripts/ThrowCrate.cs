using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowCrate : MonoBehaviour
{
    public bool thrown = false;

    private bool grounded = false;

  [SerializeField] GameObject[] breakableObj;

    int i = 0;
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
       if(thrown && grounded)
        {

            GetComponent<MeshRenderer>().forceRenderingOff = true;
            for (i = 0; i < breakableObj.Length; i++)
            {
                breakableObj[i].SetActive(true);
            }
        }
    }


    public void Set()
    {
        thrown = true;
    }


    public void Reset ()
    {

        thrown = false;


        
    }


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            grounded = true;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            grounded = false;
        }
    }
}
