using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenDoor : MonoBehaviour
{
   [SerializeField] private bool open = false;

    private bool opened = false;

    [SerializeField] Transform openDoorPos;

    [SerializeField] Transform closedDoorPos;
    [SerializeField] private float speed;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(open && !opened)
        {
            transform.position = Vector3.MoveTowards(transform.position, openDoorPos.position, speed * Time.deltaTime);

            if(Vector3.Distance(transform.position,openDoorPos.position) <= 0.01f)
            {
                opened = true;
            }
        }


        if(!open && opened)
        {
            transform.position = Vector3.MoveTowards(transform.position, closedDoorPos.position, speed * Time.deltaTime);

            if (Vector3.Distance(transform.position, closedDoorPos.position) <= 0.01f)
            {
                opened = false;
            }
        }
    }


    public void Set()
    {

        open = !open;
    }
}
