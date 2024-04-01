using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using System;
using UnityEngine.SceneManagement;

public class MH_Timeline : MonoBehaviour
{
    //this way we can make scenes, and set up questions along with flashbacks
    [Serializable]
    public class scene {
        public string name;
        public UnityEvent action;
        public bool needsInput, isObj, isScene;
        public UnityEvent animation;
        public UnityEvent fadeOut;
        public AudioClip recording;
        public float time;
       
    }
 
    public List<scene> scenes = new List<scene>();

    [SerializeField]
    private MH_AudioSourcer source;

    [SerializeField]
    private MH_SwitchCamera sc;

    [SerializeField]
    private string buttonTagName;

    public int progression = 0;

    bool inputDetected, start, isEnd;
    scene obj = null;

   IEnumerator gameState(){
        //iterates scenes until the end, allow for questions to play 
       for(int currentScene = progression; currentScene < scenes.Count -1; currentScene++){
             
           if(!isEnd){
                        
                   progression = currentScene;
               source.endAudio(3);
            obj = scenes[currentScene];
            yield return new WaitUntil(()=> !sc.isInventory);
           source.playClip(scenes[currentScene].recording,3,1f,false);
            if(scenes[currentScene].action != null)
                scenes[currentScene].action.Invoke();
           
            if(scenes[currentScene].needsInput)
                yield return new WaitUntil(() => inputDetected);
                inputDetected = false;
           scenes[currentScene].animation.Invoke();
           /* if(GameObject.FindGameObjectWithTag(buttonTagName) != null && scenes[currentScene].isObj){
                yield return new WaitUntil(() => pressObj());
            }*/
                if(scenes[currentScene].isScene){

                }else{
                yield return new WaitForSeconds(scenes[currentScene].time);
                }

                   yield return new WaitForSeconds(0.25f);
          
                  
           }
        }
        
        scenes[scenes.Count - 1].action.Invoke();
        Debug.Log(source.getAudioSource(0).isPlaying);
        yield return new WaitUntil(() => !source.getAudioSource(0).isPlaying);
        source.playClip(scenes[scenes.Count - 1].recording,0,0.7f,false);
        yield return new WaitForSeconds(scenes[scenes.Count - 1].time);
        scenes[scenes.Count - 1].fadeOut.Invoke();
        
        
    }

    public void isInput(){
      inputDetected = true;
      obj.fadeOut.Invoke();
    }

    public void endGame(){
        isEnd = true;
    }

    public bool pressObj(){
       RaycastHit hit; 
       bool b = false;
       Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if(Physics.Raycast(ray, out hit, Mathf.Infinity)){
            if(hit.collider.gameObject.tag == "Choice"){
                b = true;
            }
        }
        return b;
    }


    public void restartGame(){
        Destroy(GameObject.Find("gameData"));
        SceneManager.LoadScene("Flashback0");
    }
    public void endTheGame(){
        Destroy(GameObject.Find("gameData"));
    }
    // Update is called once per frame
    void Update()
    {
        pressObj();
        if(start == false){
       StartCoroutine(gameState());  
          start = true;
        }

        
    }
}