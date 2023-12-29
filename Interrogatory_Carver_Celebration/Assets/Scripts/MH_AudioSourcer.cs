using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MH_AudioSourcer: MonoBehaviour
{
    public List<AudioSource> audioList;

    public void playMultiple(AudioClip clip1, AudioClip clip2, AudioClip clip3, bool l){
          playClip(clip1,0,0.5f,l);
          playClip(clip2,1,0.2f,l);
          playClip(clip3,2,0.1f,l);   
    }

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

    public AudioSource getAudioSource(int i){
        return audioList[i];
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
