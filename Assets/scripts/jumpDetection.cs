using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class jumpDetection : MonoBehaviour
{
    move moveScript ;
    // Start is called before the first frame update
    void Start()
    {
        moveScript = transform.parent.GetComponent<move>();
        Physics.IgnoreLayerCollision(8,9);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay(Collider col)
    {
        if (col.gameObject.layer == 10)
        {
            moveScript.EnableJump();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == 10)
            moveScript.spad = true;

            // moveScript.GetComponent<Animator>().Play("idle");
    
    }

    // private void OnTriggerExit(Collider col)
    // {
    //     if (col.gameObject.layer == 10)
    //     {
    //         moveScript.DisableJump();
    //     }
    // }
    
}
