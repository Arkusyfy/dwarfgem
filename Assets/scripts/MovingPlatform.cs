using System.Collections;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    private bool doUpdate = true;

    // public float speed = 2f;
    private float elapsedTime;

    // Start is called before the first frame update
    private int movDir = 1;
    private bool movingRight = true;
    private Vector3 otPos;
    public float tiem = 2f;
    private Vector3 toPos;

	public float distance=15f;
	
    private void Start()
    {
        otPos = transform.position;
        toPos = otPos + Vector3.right * (distance * movDir);
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        if (!doUpdate) return;

        if (elapsedTime < tiem)
        {
            transform.position = Vector3.Lerp(otPos, toPos, elapsedTime / tiem);
            elapsedTime += Time.fixedDeltaTime;
        }
        else
        {
            otPos = transform.position;
            movDir *= -1;
            toPos = otPos + Vector3.right * (distance * movDir);

            StartCoroutine(waitNSwitch(1f));
        }
    }

    private IEnumerator waitNSwitch(float delay)
    {
        doUpdate = false;
        yield return new WaitForSeconds(delay);
        doUpdate = true;
        elapsedTime = 0;
    }

    // private IEnumerator moveDoor(float time)
    // {
    //        
    //      
    //     while (elapsedTime < time)
    //     {
    //         transform.position = Vector3.Lerp(otPos, toPos, (elapsedTime / time));
    //         elapsedTime += Time.deltaTime;
    //         yield return null;
    //     }
    //     isMoving = false;
    //     flipped *= -1;
    // }
}