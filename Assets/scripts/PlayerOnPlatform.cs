using UnityEngine;

public class PlayerOnPlatform : MonoBehaviour
{
    // Start is called before the first frame update
    private void Start()
    {
    }

    // Update is called once per frame
    private void Update()
    {
    }

    //
    // private void OnCollisionEnter(Collision other)
    // {
    //     if (other.gameObject.CompareTag("jumpCol")) other.transform.parent.transform.SetParent(gameObject.transform);
    // }
    //
    // private void OnCollisionExit(Collision other)
    // {
    //     if (other.gameObject.CompareTag("jumpCol")) other.transform.parent.transform.SetParent(null);
    // }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("movingPlat")) transform.parent.transform.SetParent(other.gameObject.transform);
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("movingPlat")) transform.parent.transform.SetParent(null);
    }
}