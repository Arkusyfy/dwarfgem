using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class leverTrigger : MonoBehaviour
{
    private int flipped = 1;

    private bool isMoving = false;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TriggerMe()
    {
        // Vector3 otPos = transform.position;
        // Vector3 toPos = new Vector3(otPos.x, otPos.y+10, otPos.z);
        // float startTime = Time.time;
        //
        // float distance = Vector3.Distance(otPos, toPos);
        //
        //
        //     float distCovered = (Time.time - startTime) * 1;
        //     transform.position = Vector3.Lerp(otPos, toPos, distCovered / distance);    
        //     
        //     distance = Vector3.Distance(otPos, toPos);
        //
        if(!isMoving)
        StartCoroutine(moveDoor(1.5f));

    }

    private IEnumerator moveDoor(float time)
    {
        isMoving = true;
        Vector3 otPos = transform.position;
        Vector3 toPos = otPos + (transform.forward * 14)*flipped;
        
        float elapsedTime = 0;
         
        while (elapsedTime < time)
        {
            transform.position = Vector3.Lerp(otPos, toPos, (elapsedTime / time));
            elapsedTime += Time.deltaTime;
            yield return null;
        }
        isMoving = false;
        flipped *= -1;
    }

    
   
}
