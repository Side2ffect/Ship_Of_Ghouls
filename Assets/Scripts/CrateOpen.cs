using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrateOpen : MonoBehaviour
{

    private bool toOpen = false;

    private bool set = false;
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if(!set && toOpen)
        {

            if (GameManager._instance.ReturnKeyCount() == 0)
            {
                GameManager._instance.SetGameWon();
                set = true;
            }
        }
        
    }

    public void WinGame()
    {
        toOpen = true;
    }

}
