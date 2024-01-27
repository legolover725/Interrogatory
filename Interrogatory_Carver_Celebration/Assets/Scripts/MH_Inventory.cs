using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MH_Inventory : MonoBehaviour
{
    public List<Sprite> evidence = new List<Sprite>();
    [SerializeField]
    private Image image;

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
          image.sprite = (s >= 0 && s < evidence.Count) ? evidence[s] : null;   
    }
    // Start is called before the first frame update
    void Start()
    {
        switcher(i);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
