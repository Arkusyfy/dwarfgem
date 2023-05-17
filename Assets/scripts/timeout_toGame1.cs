using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class timeout_toGame1 : MonoBehaviour
{
    
    IEnumerator test()
    {
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene("Poziom1");
    }
    
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(test());

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
