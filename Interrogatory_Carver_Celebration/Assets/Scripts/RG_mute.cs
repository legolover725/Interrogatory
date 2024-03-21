using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RG_mute : MonoBehaviour
{
    private Image image;
    [SerializeField] Sprite mute;
    [SerializeField] Sprite unmute;
    // Start is called before the first frame update
    void Start()
    {
        image = GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    //used to change the mute state
    public void changeMuteState(){
        MH_AudioSourcer audioSourcer = GameObject.Find("Main Camera").GetComponent<MH_AudioSourcer>();
        //if muted, display the unmute sprite and switch to unmuted
        if(audioSourcer.mute){
            image.sprite = unmute;
            audioSourcer.mute = !audioSourcer.mute;
        }
        //if not muted, display the mute sprite and switch to muted
        else if(!audioSourcer.mute){
            image.sprite = mute;
            audioSourcer.mute = !audioSourcer.mute;
        }
    }
}
