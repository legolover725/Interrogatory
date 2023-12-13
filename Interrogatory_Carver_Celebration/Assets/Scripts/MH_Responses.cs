using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

public class MH_Responses : MonoBehaviour
{
    [Serializable]
    public class questionList {
        public string question;
        public List<string> answer = new List<string>();
        public int suspicionLevel; 
    }
   
    public List<questionList> list = new List<questionList>();
    public GameObject[] buttonList;
    public void assignValue(){
        for(int i = 0; i < list.Count; i++){
            for(int y = 0; y < list[i].answer.Count; y++){
                buttonList[y].GetComponent<Text>().text = list[i].answer[y];
            }
        }

    }
    
    public void getEvent(){

    }

    // Start is called before the first frame update
    void Start()
    {
        assignValue();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
