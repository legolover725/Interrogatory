using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MH_CameraDirect : MonoBehaviour
{
    
     private IEnumerator courotine = null; 
     private Vector3 rot = Vector3.zero; 
    // Start is called before the first frame update 

    void Start() 
    { 

    } 

    // Update is called once per frame 
    void Update() 
    { 

         if(Input.GetMouseButtonDown(0) && !detectHit()){  

            Vector3 mousePos = Camera.main.ScreenToViewportPoint(Input.mousePosition);  
            float pos = mousePos.x;
            if(this.courotine == null){
                float y = mousePos.x < 0.3f ? -20 : mousePos.x > 0.7 ? 20 : 0;
                float x = (mousePos.y < 0.3f) ? 10: mousePos.y > 0.7 ? -10 : 0;
                rot += new Vector3(x,y);
                this.courotine = transition(rot);
            }

            if(courotine != null) 

                StartCoroutine(this.courotine); 

        }  
    } 

    public bool detectHit(){ 
        RaycastHit hit; 
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition); 
        return Physics.Raycast(ray,out hit, Mathf.Infinity, 1 << 5); 
    } 

     IEnumerator transition(Vector3 r){
        Quaternion l = Quaternion.Euler(new Vector3(Mathf.Clamp(r.x,-10,10),Mathf.Clamp(r.y,-20,20),0));   
            float time = 0.5f;  
            float t = 0;    

            while(t < time){  
                transform.rotation = Quaternion.RotateTowards(transform.rotation,l,t/time);  
                t += Time.deltaTime;  
                yield return null;   
            }  
            courotine = null; 
    } 
}