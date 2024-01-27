using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using Cinemachine;

public class MH_CameraDirect : MonoBehaviour
{
    
     private IEnumerator courotine = null; 
     private Vector3 rot = Vector3.zero; 
     private GameObject cam;
    // Start is called before the first frame update 

    void Start() 
    { 
        cam =  GameObject.Find("PlayerCamera");
    } 

    // Update is called once per frame 
    void Update() 
    { 
         if(Input.GetMouseButtonDown(0) && !detectHit() && cam.GetComponent<CinemachineVirtualCamera>().Priority == 15){  
             
            Vector3 mousePos = Camera.main.ScreenToViewportPoint(Input.mousePosition);  
            float pos = mousePos.x;
            if(this.courotine == null){
                //determines where you are pressing
                float y = mousePos.x < 0.3f ? -20 : mousePos.x > 0.7 ? 20 : 0;
                float x = (mousePos.y < 0.3f) ? 10: mousePos.y > 0.7 ? -10 : 0;
                Debug.Log("click");
                rot += new Vector3(x,y);
                //rotation is clamped
                rot.y = Mathf.Clamp(rot.y,-20,20);
                rot.x = Mathf.Clamp(rot.x,-10,10);
                this.courotine = transition(rot);
            }

            if(courotine != null) 
                StartCoroutine(this.courotine); 
            }  
    } 

    public bool detectHit(){ 
        //raycast determines if there is a object or UI on top of the mouse so that when clicking a button or UI object, the camera doesn't move
        RaycastHit hit; 
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition); 
        return Physics.Raycast(ray,out hit, Mathf.Infinity, 1 << 5) || !Input.anyKey || EventSystem.current.currentSelectedGameObject != null || EventSystem.current.IsPointerOverGameObject();
    } 

     IEnumerator transition(Vector3 r){
        Quaternion l = Quaternion.Euler(new Vector3(r.x,r.y,0));   
            float time = 0.5f;  
            float t = 0;    
            //lerping the camera to have smooth transitions
            while(t < time){  
               cam.transform.rotation = Quaternion.RotateTowards(transform.rotation,l,t/time);  
                t += Time.deltaTime;  
                yield return null;   
            }  
            courotine = null; 
    } 
}