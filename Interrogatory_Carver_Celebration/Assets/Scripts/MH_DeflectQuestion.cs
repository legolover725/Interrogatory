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
        public List<string> question = new List<string>();
        public List<string> response;
    }
    [SerializeField]
    private List<playerQuestion> questions = new List<playerQuestion>();

    [SerializeField]
    private MH_ButtonSpawner spawner;
    [SerializeField]
    private GameObject image;
    [SerializeField]
    private UnityEvent action;
    private GameObject[] o;
    int progression = 0;

    public void askQuestion(){
        o = spawner.buttonSpawn(questions[progression].question.Count,o);
        image.GetComponent<Text>().text = "";
        for(int i = 0; i < questions[progression].question.Count; i++){
            o[i].transform.GetChild(0).GetComponent<Text>().text = questions[progression].question[i];
            o[i].GetComponent<Button>().onClick.RemoveAllListeners();
            o[i].GetComponent<Button>().onClick.AddListener(() => respond());
        }
    }

    public void respond(){
       string o = EventSystem.current.currentSelectedGameObject.transform.GetChild(0).GetComponent<Text>().text;
       int index = (o != "" || o != null) ? questions[progression].question.FindIndex(s => s == o): 0;
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
