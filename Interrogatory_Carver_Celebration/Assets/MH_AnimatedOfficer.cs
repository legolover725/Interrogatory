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
            name.GetComponent<Animation>().Play(animation.name);
        }
    }
    public List<AnimationObject> animObjs = new List<AnimationObject>();
    public AnimationObject blink;
    public AnimationObject eyeLoop;

    public bool replaced;

    public IEnumerator eyeAnimation(){
        eyeLoop.playClip();
         yield return new WaitForSeconds(4.0f);
         yield return new WaitUntil(() => replaced);
        StartCoroutine(eyeAnimation());
        
    }

    public void randomAnimation(){
        AnimationObject ao = animObjs[UnityEngine.Random.Range(0,animObjs.Count)];
        ao.playClip();
        StartCoroutine(endClip(ao.animation));

    }
    public IEnumerator endClip(AnimationClip a){
        replaced = false;
        yield return new WaitForSeconds(a.length);
        replaced = true;
        yield return null;
    }
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(eyeAnimation());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
