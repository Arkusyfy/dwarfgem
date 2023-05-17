using UnityEngine;

public class ladder : MonoBehaviour
{
    // Start is called before the first frame update
    private void Start()
    {
    }

    // Update is called once per frame
    private void Update()
    {
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.CompareTag("Player"))
        {
            other.GetComponent<move>().SetLadder(true);
            other.GetComponent<Animator>().Play("idle");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.transform.CompareTag("Player"))
            other.GetComponent<move>().SetLadder(false);
    }
}