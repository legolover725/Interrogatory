using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class MH_Animatedeer : MonoBehaviour
{
   [Serializable]
    public class AnimationObject{
        public GameObject name;
        public AnimationClip animation;
       


        public void playClip(){
          
            name.GetComponent<Animation>().Play(animation.name);
            
           // name.GetComponent<Animation>().Play(a.name);
        }
 
    }
    [Serializable]
    public class animList{
        public List<AnimationObject> aList = new List<AnimationObject>();
    }
    public List<animList> animObjs = new List<animList>();
    public AnimationObject talk;
    public AnimationObject eyeLoop;
    public AudioSource source;
    public bool replaced = false;
    public GameObject head;
    public IEnumerator play(AnimationClip a1,AnimationClip a2, GameObject name){
        replaced = true;
        yield return new WaitForSeconds(a1.length);
        replaced = false;
        if(a2 != null)
        name.GetComponent<Animation>().Play(a2.name);
        if(name == head){
           // head.transform.position = new Vector3(0,0,0);
            //head.transform.rotation = Quaternion.Euler(0,0,0);
        }
    }

    public void randomAnimation(){
        animList ao = animObjs[UnityEngine.Random.Range(0,animObjs.Count)];
        for(int i = 0; i < ao.aList.Count; i++){
              AnimationClip a = null;
            if(ao.aList[i].name.GetComponent<Animation>().clip != ao.aList[i].animation && ao.aList[i].name.GetComponent<Animation>().clip != null)
                a = ao.aList[i].name.GetComponent<Animation>().clip;
            ao.aList[i].playClip();
            StartCoroutine(play(ao.aList[i].animation, a, ao.aList[i].name));  
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
        if(source.clip != null && source.isPlaying && replaced == false){
            talk.name.GetComponent<Animation>().Play(talk.animation.name);
        }else{
            talk.name.GetComponent<Animation>().clip = null;
        }
    }
}
