using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camAnim : MonoBehaviour
{
    public GameObject player;
    // Start is called before the first frame update
    private float folSpd = 10f;
    public Vector3 offset;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        transform.position = Vector3.Lerp( transform.position-offset, player.transform.position, folSpd * Time.fixedDeltaTime)+offset;
        
    }
}
