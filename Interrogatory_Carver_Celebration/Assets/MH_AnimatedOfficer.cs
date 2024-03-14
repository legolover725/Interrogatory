using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class MH_AnimatedOfficer : MonoBehaviour
{
   [Serializable]
    public class AnimationObject{
        public GameObject name;
        public AnimationClip animation;

        public void playClip(){
            AnimationClip a = null;
            if(name.GetComponent<Animation>().clip != animation && name.GetComponent<Animation>().clip != null)
                a = name.GetComponent<Animation>().clip;
            
            name.GetComponent<Animation>().Play(animation.name);
          
           // name.GetComponent<Animation>().Play(a.name);
        }
 
    }
    [Serializable]
    public class animList{
        public List<AnimationObject> aList = new List<AnimationObject>();
    }
    public List<animList> animObjs = new List<animList>();
    public AnimationObject blink;
    public AnimationObject eyeLoop;

    public bool replaced;



    public void randomAnimation(){
        animList ao = animObjs[UnityEngine.Random.Range(0,animObjs.Count)];
        for(int i = 0; i < ao.aList.Count; i++){
            ao.aList[i].playClip();
            
        }

    }
    
    // Start is called before the first frame update
    void Start()
    {
       eyeLoop.name.GetComponent<Animation>().Play(eyeLoop.animation.name);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
