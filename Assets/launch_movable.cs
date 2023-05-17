using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class launch_movable : MonoBehaviour
{
    // Start is called before the first frame update
    private float speed = 1500;
    public bool canLaunch = false;
    private Animator bounceAnim;
    private ParticleSystem _particleSystem;
    void Start()
    {
        _particleSystem = gameObject.transform.Find("Particle System").GetComponent<ParticleSystem>();
        bounceAnim = gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnCollisionEnter(Collision other)
    {

        if (other.gameObject.layer == 10)
        {
            gameObject.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
            canLaunch = true;
        }
        
        if (other.gameObject.CompareTag("Player") && canLaunch)
        {
            _particleSystem.Play();
            bounceAnim.Play("bounce");
            other.gameObject.GetComponent<Rigidbody>().velocity=Vector3.zero;

            other.gameObject.GetComponent<Rigidbody>
                ().AddForce(Vector3.up*speed);
            other.gameObject.GetComponent<Animator>().Play("jump");

        }
    }
}
