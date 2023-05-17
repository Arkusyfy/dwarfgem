using UnityEngine;

public class click_exit : MonoBehaviour
{
    private Animator camAnim;

    public Material newMat;

    // Start is called before the first frame update
    private Material[] prevMat;
    private Material[] matArr = new Material[2];
    private void Start()
    {
        camAnim = GameObject.Find("Main Camera").GetComponent<Animator>();

        prevMat = transform.parent.GetComponent<Renderer>().sharedMaterials;
        matArr[0] = prevMat[0];
        matArr[1] = newMat;
    }

    // Update is called once per frame
    // private Material newMaterial = Resources.Load("SpatialMappaingWireframe");
    private void Update()
    {
        //Debug.Log(AssetDatabase.LoadAllAssetsAtPath("Resources/unity_builtin_extra").);
        RaycastHit hit;
        var ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out hit, 1000.0f))
        {
            if (hit.collider.name == "exit")
            {
                transform.parent.GetComponent<MeshRenderer>().materials = matArr;
                if (Input.GetMouseButtonDown(0))
                    Application.Quit();
            }
        }
        else
        {
            // Debug.Log(GetComponent<MeshRenderer>().material.name);
            transform.parent.GetComponent<MeshRenderer>().materials = prevMat;
        }
    }
}