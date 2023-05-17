using System;
using UnityEngine;
using UnityEngine.Rendering;

public class isHolding : MonoBehaviour
{
    private GameObject clone;
    private GameObject holdObj;
    private GameObject Q_to_place;
    private move moveScr;
    // Start is called before the first frame update

    public bool IsNull()
    {
        if (holdObj == null)
            return true;
        return false;
    }

    private void Start()
    {
        moveScr = transform.GetComponent<move>();
        Q_to_place = Camera.main.transform.Find("Canvas").Find("Press_Q").gameObject;

    }


    // Update is called once per frame

    private void Update()
    {
        var facing = moveScr.GetFacing();
        if (!IsNull())
        {
            var xPos = holdObj.transform.position.x;
            // if ((facing > 0 && xPos < 0) || (facing < 0 && xPos > 0))
                // clone.transform.localPosition = Vector3.Scale(clone.transform.localPosition, new Vector3(-1f, 1f, 1f));
                Vector3 locPos = holdObj.transform.localPosition;
                // clone.transform.localPosition = new Vector3(Math.Abs(locPos.x)*facing,locPos.y,locPos.z);
        }

        if (Input.GetKeyDown(KeyCode.Q) && !IsNull()) PlaceObject();
    }

    public void PlaceObject()
    {
        // var facing = moveScr.GetFacing();
        //holdObj.transform.position += new Vector3(5 * facing, -1f, 0);
        Q_to_place.SetActive(false);
        RemoveHold();
    }

    public void SetHold(GameObject newHold)
    {
        Q_to_place.SetActive(true);
        holdObj = newHold;
        var rb = holdObj.GetComponent<Rigidbody>();
        rb.detectCollisions = false;
        rb.constraints = RigidbodyConstraints.FreezeAll;
        holdObj.transform.SetParent(transform);
        holdObj.transform.position = holdObj.transform.parent.position + new Vector3(0.24f, 3, 0);
        holdObj.GetComponent<Rigidbody>().detectCollisions = false;

        holdObj.transform.position += new Vector3(3 * moveScr.GetFacing() + .24f, -1f-2.02f, 1.94f);
    }

    // public void Transparentise(Material mat)
    // {
    //     mat.SetOverrideTag("RenderType", "Transparent");
    //     mat.SetInt("_SrcBlend", (int) BlendMode.SrcAlpha);
    //     mat.SetInt("_DstBlend", (int) BlendMode.OneMinusSrcAlpha);
    //     mat.SetInt("_ZWrite", 0);
    //     mat.DisableKeyword("_ALPHATEST_ON");
    //     mat.EnableKeyword("_ALPHABLEND_ON");
    //     mat.DisableKeyword("_ALPHAPREMULTIPLY_ON");
    //     mat.renderQueue = (int) RenderQueue.Transparent;
    //     mat.SetColor("_Color", new Color(mat.color.r, mat.color.g, mat.color.b, .2f));
    // }

    public void RemoveHold()
    {
        //Destroy(clone);
        //clone = null;
        var rb = holdObj.GetComponent<Rigidbody>();
        rb.detectCollisions = true;
        rb.constraints = RigidbodyConstraints.FreezePositionZ | RigidbodyConstraints.FreezePositionX |
                         RigidbodyConstraints.FreezeRotation;
        holdObj.GetComponent<launch_movable>().canLaunch = false;
        holdObj.transform.position += new Vector3(moveScr.GetFacing()*2f,0,-1.94f);
        holdObj.transform.SetParent(null);
        holdObj = null;
    }
}