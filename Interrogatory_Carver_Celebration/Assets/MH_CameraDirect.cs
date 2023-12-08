using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MH_CameraDirect : MonoBehaviour
{
    [SerializeField]
    private int y = 0;

    [SerializeField]
    private float g = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0)){
            Vector3 mousePos = Camera.main.ScreenToViewportPoint(Input.mousePosition);
            float pos = mousePos.x;
            if(pos < 0.5){
                StartCoroutine(transition(y,-20));
            }else{
                StartCoroutine(transition(y,20));
            }
            
            //y = Mathf.Clamp(y,-90,90);
            
            y = 0;
            pos = 0;
        }
    }

    IEnumerator transition(float value, float goalValue){
          g += goalValue;
        Quaternion l = Quaternion.Euler(new Vector3(0,g,0));
          
            //y = Mathf.Clamp(y,-90,90);
            float time = 0.5f;
            float t = 0;
            while(t < time){
            transform.rotation = Quaternion.RotateTowards(transform.rotation,l,t/time);
            t += Time.deltaTime;
            yield return null;
            }
    }
}