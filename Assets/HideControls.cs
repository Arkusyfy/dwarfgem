using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HideControls : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(AssetDatabase.LoadAllAssetsAtPath("Resources/unity_builtin_extra").);
        RaycastHit hit;
        var ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out hit, 1000.0f))
        {
            
            if (hit.collider.name == "RawImage")
            {
                
                if (Input.GetMouseButtonDown(0))
                    gameObject.SetActive(false);
                }
        }

    }
    
}
