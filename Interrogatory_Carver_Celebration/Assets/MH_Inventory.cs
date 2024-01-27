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
        i++;
        switcher(i);
    }

    public void less(){
        i--;
        switcher(i);
    }
    public void switcher(int s){
        if(s >= 0 && s < evidence.Count){
          image.sprite = evidence[s];
        }
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
