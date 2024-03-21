using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MH_SetScene : MonoBehaviour
{
    public MH_SaveData sd;
    public string t;
    public string l;
    public float duration;

    public void sceneLoad(){
        if(sd != null)
            sd.convertToData();
        SceneManager.LoadScene(t);
    }
    // Start is called before the first frame update
    void Start()
    {
       StartCoroutine(delayTime(l,duration));  
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
