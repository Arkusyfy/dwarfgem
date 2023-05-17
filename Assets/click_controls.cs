using UnityEngine;

public class click_controls : MonoBehaviour
{
    private Animator camAnim;

    public Material newMat;

    // Start is called before the first frame update
    private Material prevMat;

    private void Start()
    {
        camAnim = GameObject.Find("Main Camera").GetComponent<Animator>();
        
        prevMat = GetComponent<Renderer>().sharedMaterials[0];
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
            
            if (hit.collider.name == "Cube.006")
            {
                GetComponent<MeshRenderer>().material = newMat;
                if (Input.GetMouseButtonDown(0))
                {
                    Camera.main.transform.GetChild(0).GetChild(0).gameObject.SetActive(true);
                }
            }
        }
        else
        {
            // Debug.Log(GetComponent<MeshRenderer>().material.name);
            GetComponent<MeshRenderer>().material = prevMat;
        }
    }
}