using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;
public class MH_ButtonSpawner : MonoBehaviour
{
    [SerializeField]
    private RectTransform obj;
    [SerializeField]
    private RectTransform group;
    [SerializeField]
    private MH_Timeline t;
    public GameObject[] buttonSpawn(int num, GameObject[] l){
        for(int i = 0; i < group.transform.childCount; i++){
            Destroy(group.transform.GetChild(i).gameObject);
        }

        l = new GameObject[4];
        for(int i = 0; i < num; i++){
            RectTransform o = Instantiate(obj, group);
            group.sizeDelta = new Vector2(200 * num,100);
            o.GetComponent<Button>().onClick.AddListener(() => t.isInput());
            o.sizeDelta = new Vector2(250,75);
            l[i] = o.gameObject;
        }
      return l;
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
