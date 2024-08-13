using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyCount : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }




    public void ReduceKey()
    {

        GameManager._instance.ReduceKeyCount();
        gameObject.SetActive(false);
    }
}
