using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class lvlEnd : MonoBehaviour
{
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
        if ( other.CompareTag("Player"))
        {
            other.gameObject.GetComponent<move>().enabled = false;
            StartCoroutine(ExitLevel(other.gameObject));
        }
    }

    IEnumerator ExitLevel(GameObject player)
    {
        player.GetComponent<Animator>().Play("exitLevel");
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);
    }
}
