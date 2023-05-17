using UnityEngine;

public class lever : MonoBehaviour
{
    private Animator dzwigAnim;

    public GameObject toHandle;

    // Start is called before the first frame update
    private void Start()
    {
        dzwigAnim = gameObject.transform.GetComponent<Animator>();
    }

    // Update is called once per frame
    private void Update()
    {
    }

    public void LeverTrigger()
    {
        if (dzwigAnim.GetCurrentAnimatorStateInfo(0).IsName("def"))
        {
            if (toHandle.GetComponent<leverTrigger>() != null)
                toHandle.GetComponent<leverTrigger>().TriggerMe();
            else
                toHandle.GetComponent<openExitGate>().TriggerMe();

            dzwigAnim.SetBool("isSwitched", true);
        }
        else if (dzwigAnim.GetCurrentAnimatorStateInfo(0).IsName("postSwitched_1"))
        {
            if (toHandle.GetComponent<leverTrigger>() != null)
                toHandle.GetComponent<leverTrigger>().TriggerMe();
            else
                toHandle.GetComponent<openExitGate>().TriggerMe();
            dzwigAnim.SetBool("isSwitched", false);
        }
    }
}