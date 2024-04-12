using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RG_changeScene : MonoBehaviour
{
    public string scene;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void setScene(string scene){
        if(scene == "Quit"){
            Application.Quit();
        }
        else{
            SceneManager.LoadScene(scene);
        }
    }
}
