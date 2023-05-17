using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class scoreCounting : MonoBehaviour
{
    public int value=10;

    public PointsHolder pointsHolder;
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
        if (other.transform.CompareTag("Player"))
        {
            pointsHolder.addPoints(value);
            Destroy(gameObject);
        }
    }
}
