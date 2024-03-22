using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MH_SetScene : MonoBehaviour
{
    public MH_SaveData sd;
    public List<string> t = new List<string>();
    public int progression;
    public string l;
    public float duration;
    public bool isInScene;

    public void sceneLoad(){
        if(sd != null){
        progression++;
            sd.convertToData();
            SceneManager.LoadScene(t[progression -1]);
        }else{
            SceneManager.LoadScene(t[0]);
        }
        
    }
    // Start is called before the first frame update
    void Start()
    {
        if(!isInScene) 
        sd = GameObject.Find("gameData").GetComponent<MH_SaveData>();
       StartCoroutine(delayTime(l,duration));  
    }
    public void endlist(){
        progression = 0;
    }

    public IEnumerator delayTime(string currentScene, float time){
         yield return new WaitForSeconds(time);
         if(SceneManager.GetActiveScene().name == currentScene)
            sceneLoad();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
