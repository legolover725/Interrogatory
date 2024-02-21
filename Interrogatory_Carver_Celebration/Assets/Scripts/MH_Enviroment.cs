using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MH_Enviroment : MonoBehaviour
{
    
    [Range(1,100)]
    public float range;
    private Color firstColor;

    [Range(50,100)]
    public float startBreathing;

    [SerializeField]
    private MH_Responses response;

    [SerializeField]
    private MH_AudioSourcer audio;

    [SerializeField]
    private AudioClip clip, clip1, clip2, clip3;

    bool isEnd;


    public void changeColorScene(){
      if(range > 50){
        firstColor.r = (range - 30)/100;
        RenderSettings.ambientLight = new Color((range-50)/100,0.0624f,0.0849f);
        if(range > startBreathing){
            audio.playClip(clip1,0,0.2f,true);
           // audio.playClip(clip2,1,0.2f,true);
        }
      }else{
        audio.getAudioSource(0).loop = false;
        audio.endAudio(0);
        //audio.endAudio(1);
        firstColor.r = 0.2f;
        RenderSettings.ambientLight = new Color(0.0460f,0.0642f,0.0849f);
      }
      GetComponent<Light>().color = firstColor;
    }

    // Start is called before the first frame update
    void Start()
    {
      audio.playClip(clip2,1,0.2f,true);
      firstColor = GetComponent<Light>().color;  
    }

    // Update is called once per frame
    void Update()
    {
        if(!isEnd){
            range = Mathf.Lerp(range,response.worryMeter,Time.deltaTime/2f);
            changeColorScene();
            if(MH_Responses.playChimes){
              Debug.Log("Play Chimes");
              //below doesn't work as intended (it doesn't play clip3)
              audio.playClip(clip3, 2, .75f, true);
            }
        }
  
    }

    public void endScene(){
        isEnd = true;
        StartCoroutine(endEvent());
    }
    public IEnumerator endEvent(){
         audio.playClip(clip,0,0.5f,false);
         while(audio.getAudioSource(0).isPlaying){
            GetComponent<Light>().color = Color.Lerp(GetComponent<Light>().color,new Color(0.1f,0.1f,0.1f),Time.deltaTime/5f);
            RenderSettings.ambientLight = Color.Lerp(RenderSettings.ambientLight, new Color(0.01f,0.01f,0.01f),Time.deltaTime/5f);
            yield return null;
         }
         yield return new WaitForSeconds(0.25f);
     
        //yield return new WaitUntil(() => !audio.getAudioSource(0).isPlaying);
    }
    
}
