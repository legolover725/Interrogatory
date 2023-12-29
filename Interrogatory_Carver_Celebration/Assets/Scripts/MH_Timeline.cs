using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using System;

public class MH_Timeline : MonoBehaviour
{
    //this way we can make scenes, and set up questions along with flashbacks
    [Serializable]
    public class scene {
        public string name;
        public UnityEvent action;
        public bool needsInput;
        public UnityEvent fadeOut;
        public AudioClip recording;
        public float time;
       
    }

    [SerializeField]
    private List<scene> scenes = new List<scene>();

    

    [SerializeField]
    private MH_AudioSourcer source;

    [SerializeField]
    private string buttonTagName;

    

    bool inputDetected;
    scene obj = null;
    // Start is called before the first frame update
    void Start()
    {
     
      StartCoroutine(gameState());  
    }

   
    
   IEnumerator gameState(){
        //iterates scenes until the end, allow for questions to play 
       int currentScene = 0;
       while(currentScene < scenes.Count - 1){
       obj = scenes[currentScene];

           if(scenes[currentScene].action != null)
        scenes[currentScene].action.Invoke();

        if(scenes[currentScene].needsInput)
            yield return new WaitUntil(() => inputDetected);
        inputDetected = false;
 
        if(GameObject.FindGameObjectWithTag(buttonTagName) != null)
            Debug.Log("cup exists");
           
        yield return new WaitForSeconds(scenes[currentScene].time);

        currentScene++;
        yield return new WaitForSeconds(0.25f);

        }
        
        scenes[scenes.Count - 1].action.Invoke();
        yield return new WaitUntil(() => !source.getAudioSource(0).isPlaying);
        source.playClip(scenes[scenes.Count - 1].recording,0,0.7f,false);
        yield return new WaitForSeconds(scenes[scenes.Count - 1].time);
        scenes[scenes.Count - 1].fadeOut.Invoke();
        
        
    }

    public void isInput(){
      inputDetected = true;
      obj.fadeOut.Invoke();
    }
    // Update is called once per frame
    void Update()
    {
    }
}