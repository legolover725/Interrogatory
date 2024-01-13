using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MH_AudioSourcer: MonoBehaviour
{
    public List<AudioSource> audioList;
    public List<AudioSource> backgroundAudio;
    public List<AudioClip> backgroundClip;
    int intense;


    public void playClip(AudioClip c, int i, float v, bool l){
       
        if(audioList[i].clip != c || c == null)
            if(audioList[i].isPlaying){
                StartCoroutine(transitSound(audioList[i],c,v,l));
            }else{
                audioList[i].clip = c;
                audioList[i].volume = v;
                audioList[i].loop = l;
                audioList[i].Play();
            }
        
    }

    public IEnumerator transitSound(AudioSource a, AudioClip c, float v, bool l){
        float t = 0;
        while(t < 0.4f){
            a.volume = Mathf.Lerp(a.volume,0.0f,t/2f);
            t += Time.deltaTime;
            yield return new WaitForSeconds(0.05f);
        }
        a.clip = c;
        a.volume = v;
        a.loop = l;
        a.Play();
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
