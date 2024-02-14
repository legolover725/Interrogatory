using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using System.Linq;

public class MH_DeflectQuestion : MonoBehaviour
{   
    [System.Serializable]
    public class playerQuestion{
        public List<q> question = new List<q>();
        public List<string> response = new List<string>();
    }
    [System.Serializable]
    public class q{
        public string ques;
        public int suspicion;
    }
    [SerializeField]
    private List<playerQuestion> questions = new List<playerQuestion>();
    [SerializeField]
    private MH_Responses r;
    [SerializeField]
    private GameObject g;

    [SerializeField]
    private MH_ButtonSpawner spawner;
    [SerializeField]
    private GameObject image;
    [SerializeField]
    private UnityEvent action;
    private GameObject[] o;
    int progression = 0;

    public void askQuestion(){
           r.list[r.progression].answers.Single(s => s.isAsk == true).isDisable = true;
        o = spawner.buttonSpawn(questions[progression].question.Count,o);
        image.GetComponent<Text>().text = "";
        for(int i = 0; i < questions[progression].question.Count; i++){
            o[i].transform.GetChild(0).GetComponent<Text>().text = questions[progression].question[i].ques;
            o[i].GetComponent<Button>().onClick.RemoveAllListeners();
            o[i].GetComponent<Button>().onClick.AddListener(() => respond());
        }
    }

    public void respond(){
       string str = EventSystem.current.currentSelectedGameObject.transform.GetChild(0).GetComponent<Text>().text;
       int index = (str != "" || str != null) ? questions[progression].question.FindIndex(s => s.ques == str): 0;
       r.suspicionMeter += questions[progression].question[index].suspicion;
       g.SetActive(true);
       image.GetComponent<Text>().text = questions[progression].response[index];
       for(int i = 0; i < questions[progression].question.Count; i++){
           if(o[i] != null)
           o[i].SetActive(false);
       } 
    }

    public void returnBackToQuestion(){
        r.assignValue();
     
        g.SetActive(false);
    }
    
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
