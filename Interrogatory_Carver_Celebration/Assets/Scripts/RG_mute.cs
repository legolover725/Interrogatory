using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RG_mute : MonoBehaviour
{
    private Image image;
    [SerializeField] Sprite muteSprite;
    [SerializeField] Sprite unmuteSprite;
    private bool mute;
    // Start is called before the first frame update
    void Start()
    {
        image = GetComponent<Image>();
        mute = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    //used to change the mute state
    public void changeMuteState(){
        //if muted, display the unmute sprite and switch to unmuted
        if(mute){
            image.sprite = unmuteSprite;
            AudioListener.volume = 1;
            mute = false;
        }
        //if not muted, display the mute sprite and switch to muted
        else if(!mute){
            image.sprite = muteSprite;
            AudioListener.volume = 0;
            mute = true;
        }
        Debug.Log("mute state: " + mute);
    }
}
