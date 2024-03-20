using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MH_AudioSourcer: MonoBehaviour
{
    public List<AudioSource> audioList;
    public List<AudioSource> backgroundAudio;
    public List<AudioClip> backgroundClip;
    int intense;


    // c is the audio clip
    // i is index of list (which audio clip you want to play)
    // v is volume
    // l specifies if an audio clip will be looped
    public void playClip(AudioClip c, int i, float v, bool l){
       
        if(audioList[i].clip != c || c == null)
            if(audioList[i].isPlaying){
              //  StartCoroutine(transitSound(audioList[i],c,v,l));
            }else{
                audioList[i].clip = c;
                audioList[i].volume = v;
                audioList[i].loop = l;
                audioList[i].Play();
                 //  StartCoroutine(transitSound(audioList[i],c,v,l));
            }
        
    }

    public IEnumerator transitSound(AudioSource a, AudioClip c, float v, bool l){
              a.Play();
        float t = 0;
        while(t < 0.5f){
            Debug.Log("start");
            a.volume = Mathf.Lerp(0.0f,a.volume,t/2f);
            t += Time.deltaTime;
            yield return new WaitForSeconds(0.05f);
        }
        a.clip = c;
        a.volume = v;
        a.loop = l;
  
    }

    public void endAudio(int i){
        audioList[i].clip = null;
    }

   
    public AudioSource getAudioSource(int i){
        return audioList[i];
    }

    public void addIntensity(int it){
        intense += it;
        for(int i = 0; i < backgroundAudio.Count; i++){
            if(intense == i){
                backgroundAudio[i].clip = backgroundClip[i];
            }else{
                backgroundAudio[i].clip = null;
            }
        }
    }

    public void audioBackground(){
        for(int i = 0; i < backgroundAudio.Count; i++){
            backgroundAudio[i].Play();
            backgroundAudio[i].loop = true;
        }
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
