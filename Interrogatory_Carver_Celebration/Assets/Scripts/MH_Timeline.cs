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
        public bool isInputted;
        public UnityEvent fadeOut;
       
        public scene(string n, UnityEvent a, bool i, UnityEvent f){
            n = name;
            action = a;
            isInputted = i;
            fadeOut = f;
        }
    }

    [SerializeField]
    private List<scene> scenes = new List<scene>();



    [SerializeField]
    private string buttonTagName;
    // Start is called before the first frame update
    void Start()
    {
     
      StartCoroutine(gameState());  
    }

   
    
   IEnumerator gameState(){
        //iterates scenes until the end, allow for questions to play 
       int currentScene = 0;
       while(currentScene < scenes.Count){
        scenes[currentScene].action.Invoke();
        if(scenes[currentScene].isInputted)
            yield return new WaitUntil(() => questionAnswered());
        currentScene++;
        yield return new WaitForSeconds(0.25f);

        }
    }

    public bool questionAnswered(){
    //determines whether a user has made an answer
        string o = (EventSystem.current.currentSelectedGameObject != null) ? EventSystem.current.currentSelectedGameObject.tag: "";
        return o == buttonTagName;
    }
    // Update is called once per frame
    void Update()
    {
    }
}