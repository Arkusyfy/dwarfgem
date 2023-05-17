using UnityEngine;

public class openExitGate : MonoBehaviour
{
    private Animator anim;

    // Start is called before the first frame update

    private void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    private void Update()
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
        if (anim.GetCurrentAnimatorStateInfo(0).IsName("def"))
        {
            anim.SetBool("isOpening", true);
            GetComponent<BoxCollider>().enabled = true;
        }
        else if (anim.GetCurrentAnimatorStateInfo(0).IsName("postSwitched_1"))
        {
            anim.SetBool("isOpening", false);
            GetComponent<BoxCollider>().enabled = false;
        }
    }
}