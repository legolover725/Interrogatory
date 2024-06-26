using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class MH_Inventory : MonoBehaviour
{
    public List<MH_Image> evidence = new List<MH_Image>();

    [System.Serializable]
    public class MH_Image{
        public Sprite s; 
        public UnityEvent ue;
        public string name;
        public MH_Image(Sprite s, UnityEvent ue, string n){
            this.s = s;
            this.ue = ue;
            name = n;
        }
    }

    [SerializeField]
    private GameObject image;
    [SerializeField]
    private Sprite report;
    [SerializeField]
    private GameObject text;
    [SerializeField]
    private MH_SwitchCamera sc;
    int i = 0;
    public void add(){
         i = (i >= 0 && i < evidence.Count -1) ? i+=1 : 0;
        switcher(i);
    }

    public void less(){
        i = (i > 0 && i < evidence.Count) ? i-=1 : evidence.Count -1;
        switcher(i);
    }
    public void switcher(int s){
          image.GetComponent<Animation>().Play();
          image.GetComponent<Image>().preserveAspect = true;
          text.GetComponent<Text>().text = evidence[s].name;
          image.GetComponent<Image>().sprite = (s >= 0 && s < evidence.Count) ? evidence[s].s : null;
          image.GetComponent<Button>().onClick.AddListener(delegate{evidence[s].ue.Invoke();});
    }

    public void rotateImage(){
        if(Input.GetMouseButton(1)){
                    Vector3 mousePos = Camera.main.ScreenToViewportPoint(Input.mousePosition);  
        Quaternion target = Quaternion.Euler(mousePos.y * 50,mousePos.x * -50,0);
        image.GetComponent<RectTransform>().rotation = Quaternion.Slerp(image.GetComponent<RectTransform>().rotation, target, Time.deltaTime * 10);
        }

        Vector3 p = new Vector3(Input.mouseScrollDelta.y,Input.mouseScrollDelta.y, Input.mouseScrollDelta.y);
            if(image.GetComponent<RectTransform>().localScale.y > 1 || Input.mouseScrollDelta.y > 0){
            image.GetComponent<RectTransform>().localScale += p * 15 * Time.deltaTime;
            }
            
        
        //image.GetComponent<RectTransform>().position = Input.mouseScrollDelta;
    }

    public void addReport(){
       
        evidence.Add(new MH_Image(report,null,"Police Report"));
        sc.accessInventory();
        switcher(evidence.Count - 1);
    }
    // Start is called before the first frame update
    void Start()
    {
        switcher(i);
     
    }

    // Update is called once per frame
    void Update()
    {
        rotateImage();
    }
}
