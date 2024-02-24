using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class RG_videoMechanics : MonoBehaviour
{
    private VideoPlayer vP;
    private Color white;
    private Color transparent;
    // Start is called before the first frame update
    void Start()
    {
        vP = GetComponent<VideoPlayer>();
        white = new Color(1f, 1f, 1f, 1f);
        transparent = new Color(1f, 1f, 1f, 0f);
        GameObject.Find("Play").GetComponent<Image>().color = transparent;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void skipVid(){
        SceneManager.LoadScene("Interrogation");
    }

    public void playPause(){
        if(GameObject.Find("Play").GetComponent<Image>().color == white && vP.isPaused){
            vP.Play();
            GameObject.Find("Play").GetComponent<Image>().color = transparent;
            GameObject.Find("Pause").GetComponent<Image>().color = white;
        }
        else if(GameObject.Find("Pause").GetComponent<Image>().color == white && vP.isPlaying){
            vP.Pause();
            GameObject.Find("Pause").GetComponent<Image>().color = transparent;
            GameObject.Find("Play").GetComponent<Image>().color = white;
        }
    }
}
