using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MH_CameraDirect : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        int y =0;
        if(Input.GetMouseButtonDown(0)){
            Vector3 mousePos = Input.mousePosition;
            Debug.Log(Camera.main.ScreenToWorldPoint(mousePos).y);
        }
        
    }
    
}
