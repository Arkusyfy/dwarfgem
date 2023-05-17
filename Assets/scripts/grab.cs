using System;
using UnityEngine;
using UnityEngine.UI;

public class grab : MonoBehaviour
{
    // Start is called before the first frame update
    private isHolding holdScr;
    private bool EPressed;
    private GameObject E_to_pick;
    private GameObject E_to_flip;

    private void Start()
    {
        holdScr = gameObject.transform.parent.GetComponent<isHolding>();
        E_to_pick = Camera.main.transform.Find("Canvas").Find("Press_E").gameObject;
        E_to_flip = Camera.main.transform.Find("Canvas").Find("Press_E_flip").gameObject;
    }

    // Update is called once per frame
    private void Update()
    {
        if (Input.GetKey(KeyCode.E))
            EPressed = true;
        else
            EPressed = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("podnoszable"))
        {
            E_to_pick.SetActive(true);
        }
        if (other.gameObject.CompareTag("lever"))
            E_to_flip.SetActive(true);

    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("podnoszable"))
        {
            E_to_pick.SetActive(false);
        }
        if (other.gameObject.CompareTag("lever"))
            E_to_flip.SetActive(false);

    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("podnoszable"))
            if (EPressed)
                if (holdScr.IsNull())
                {
                    holdScr.SetHold(other.gameObject);
                    other.gameObject.transform.parent = gameObject.transform.parent;
                    // other.gameObject.transform.position = transform.parent.position + new Vector3(0.24f, 3, 0);
                    transform.parent.GetComponent<Animator>().Play("podnoszenie");                

                }

        if (other.gameObject.CompareTag("lever"))
            if (EPressed)
            {
                other.gameObject.GetComponent<lever>().LeverTrigger();
                transform.parent.GetComponent<Animator>().Play("interacting");                
            }
    }
}