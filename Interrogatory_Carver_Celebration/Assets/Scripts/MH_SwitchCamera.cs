using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using System.Linq;
using UnityEngine.UI;

public class MH_SwitchCamera : MonoBehaviour
{
    public List<CinemachineVirtualCamera> camera = new List<CinemachineVirtualCamera>();
    private CinemachineVirtualCamera activeCamera;
    public MH_Responses r;
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
              switchCamera(camera[1]);
            p.GetComponent<MH_Responses>().FadeChoice(p.GetComponent<CanvasGroup>(),0);
               p.GetComponent<MH_Responses>().FadeChoice(GetComponent<CanvasGroup>(),1);
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

    public void responder(){
        Debug.Log("accessed");
        string str = EventSystem.current.currentSelectedGameObject.transform.GetChild(0).GetComponent<Text>().text;
            if(str == "Go to inventory"){
                i++;
                r.list[r.progression].answers.Single(s => s.answer == str).isDisable = true;
                r.assignValue();
            }
    }
}
