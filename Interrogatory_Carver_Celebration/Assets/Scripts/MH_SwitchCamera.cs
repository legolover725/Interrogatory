using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class MH_SwitchCamera : MonoBehaviour
{
    public List<CinemachineVirtualCamera> camera = new List<CinemachineVirtualCamera>();
    private CinemachineVirtualCamera activeCamera;
    [SerializeField]
    private GameObject p;
    int i = 0;

    public void switchCamera(CinemachineVirtualCamera c){
        if(activeCamera != c){
        c.Priority = 15;
        activeCamera = c;
            foreach(CinemachineVirtualCamera cam in camera){
                if(cam != c){
                    cam.Priority = 10;
                }
            }
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        p.GetComponent<MH_Responses>().FadeChoice(GetComponent<CanvasGroup>(),0);
    }

    // Update is called once per frame
    void Update()
    {
         if(i%2 == 1){
            p.GetComponent<MH_Responses>().FadeChoice(p.GetComponent<CanvasGroup>(),0);
         }
        if(Input.GetKeyDown("i")){
            i++;
            if(i%2 == 1){
                switchCamera(camera[1]);
                p.GetComponent<MH_Responses>().FadeChoice(p.GetComponent<CanvasGroup>(),0);
                p.GetComponent<MH_Responses>().FadeChoice(GetComponent<CanvasGroup>(),1);
            }else{
                switchCamera(camera[0]);
                 p.GetComponent<MH_Responses>().FadeChoice(p.GetComponent<CanvasGroup>(),1);
                 p.GetComponent<MH_Responses>().FadeChoice(GetComponent<CanvasGroup>(),0);
            }
        }
    }
}
