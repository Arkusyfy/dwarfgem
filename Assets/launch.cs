using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class launch : MonoBehaviour
{
    // Start is called before the first frame update
    private float speed = 1720;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnCollisionEnter(Collision other)
    {

        if (other.gameObject.CompareTag("Player"))
        {
            other.gameObject.GetComponent<Rigidbody>().velocity=Vector3.zero;
            
            other.gameObject.GetComponent<Rigidbody>
                ().AddForce(Vector3.up*speed);
            // other.gameObject.GetComponent<Animator>().Play("jump");
            other.gameObject.GetComponent<Animator>().SetTrigger("isJumping");
            other.gameObject.GetComponent<Animator>().ResetTrigger("spdanie");
            other.gameObject.GetComponent<move>().spadanie = false;

        }
    }
}
