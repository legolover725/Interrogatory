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
        //creates new colors for white (no tint on image) and transparent (image isn't visible)
        white = new Color(1f, 1f, 1f, 1f);
        transparent = new Color(1f, 1f, 1f, 0f);
        //sets play button to invisible
        GameObject.Find("Play").GetComponent<Image>().color = transparent;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //loads interrogation scene to skip video
    public void skipVid(){
        SceneManager.LoadScene("SampleScene");
    }

    //used to reverse the play-state of the video
    public void playPause(){
        //when play button is visible and the video is paused, play the video and swap the visibility of the play and pause buttons
        if(GameObject.Find("Play").GetComponent<Image>().color == white && vP.isPaused){
            vP.Play();
            GameObject.Find("Play").GetComponent<Image>().color = transparent;
            GameObject.Find("Pause").GetComponent<Image>().color = white;
        }
        //when pause button is visible and the video is played, pause the video and swap the visibility of the play and pause buttons
        else if(GameObject.Find("Pause").GetComponent<Image>().color == white && vP.isPlaying){
            vP.Pause();
            GameObject.Find("Pause").GetComponent<Image>().color = transparent;
            GameObject.Find("Play").GetComponent<Image>().color = white;
        }
    }
}
