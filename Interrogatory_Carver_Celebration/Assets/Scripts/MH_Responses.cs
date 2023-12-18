using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;
using System.Linq;
using UnityEngine.EventSystems;

public class MH_Responses : MonoBehaviour
{
    [Serializable]
    public class questionList {
        [TextAreaAttribute]
        public string question;
        public List<answerObj> answers = new List<answerObj>();
    }
    [Serializable]
    public class answerObj{
        [TextAreaAttribute]
        public string answer;
        public double suspicion;
    }
    public List<questionList> list = new List<questionList>();
    [SerializeField]
    private GameObject[] buttonList;

    [SerializeField]
    private GameObject textObj;

    private int progression;
  
    public double suspicionMeter;
    
    public CanvasGroup cg;

    questionList obj;
 
    public void assignValue(){
        cg.alpha = 1;
        cg.blocksRaycasts = true;
        //loops to plaster the answers on the buttons 
        textObj.GetComponent<Text>().text = obj.question;
      for(int i = 0; i < obj.answers.Count; i++){
        buttonList[i].transform.GetChild(0).GetComponent<Text>().text = obj.answers[i].answer;
      }

    }
   
    public void minusSuspicion(){
    //the button object
        GameObject o = EventSystem.current.currentSelectedGameObject;
        string name = o.transform.GetChild(0).GetComponent<Text>().text;
       //determines whether a name similar to that of the buttons 
        answerObj results = (name != "") ? obj.answers.Single(s => s.answer == name): null;
        //minus the suspicion based on the suspicion value of the question
        if(results != null && progression < list.Count){
           suspicionMeter = suspicionMeter + results.suspicion;
          progression++;
          if(progression < list.Count)
          obj = list[progression];
        }
        FadeOut();     
    }

    void Awake(){
        obj = list[progression];
    }
    
    public void FadeOut(){
        cg.alpha = 0;
        cg.blocksRaycasts = false;
    }
}
