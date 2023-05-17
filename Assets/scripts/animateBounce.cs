using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class animateBounce : MonoBehaviour
{
    private Animator grzp;
    // Start is called before the first frame update
    private ParticleSystem _particleSystem;
    void Start()
    {
        _particleSystem = gameObject.transform.parent.transform.Find("Particle System").GetComponent<ParticleSystem>();
        grzp = this.transform.parent.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision other)
    {
        _particleSystem.Play();
        grzp.Play("bounce");  
    }
}
