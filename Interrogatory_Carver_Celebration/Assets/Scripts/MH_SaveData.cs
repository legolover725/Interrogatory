using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MH_SaveData : MonoBehaviour
{
    private static MH_SaveData playerInstance;
    [SerializeField]
    private bool needsDestroyed = false;
    
    public class gameState{
        public int p1, p2, p3;
        public float s;
        public float[] scoreSystem;
        public List<MH_Inventory.MH_Image> e = new List<MH_Inventory.MH_Image>();
       
        public gameState(MH_Responses r, MH_Timeline t,MH_Inventory inv, MH_SetScene ss){
            p1 = r.progression;
            s = r.suspicionMeter;
            p2 = t.progression;
            e = inv.evidence;
            p3 =ss.progression;
            scoreSystem = new float[r.list.Count];
            for(int i = 0; i < scoreSystem.Length; i++){
                scoreSystem[i] = r.list[i].score;
            }
        }

        public void spreadData(MH_Responses r, MH_Timeline t, MH_Inventory inv,MH_SetScene ss){
            Debug.Log(p2);
            if(p2 == 0){
           p2++;
            }else{
                p2++;
            }
            t.progression = p2;
            r.progression = p1;
            ss.progression = p3;
            r.suspicionMeter = s;
            inv.evidence = e;
             for(int i = 0; i < scoreSystem.Length; i++){
                r.list[i].score = scoreSystem[i];
            }
        }
    }
    public MH_Responses r;
    public MH_Timeline t;
    public MH_SetScene ss;
    public MH_Inventory inv;
    public gameState g;
    public int s,y,o;
    public void convertToData(){
        if(r != null && t != null){
        g = new gameState(r,t,inv,ss);
        s = g.p1;
        y = g.p2;
        }
    }

    public void endObject(){
        needsDestroyed = true;
       Destroy(gameObject);
    }

    public void putData(){
        if(g != null)
        g.spreadData(r,t,inv,ss);
    }

    void Awake(){
      
          if(playerInstance == null){
                playerInstance = this;
                DontDestroyOnLoad(this.gameObject);
          }else{
               Destroy(gameObject);
          }
          SceneManager.sceneLoaded += OnSceneLoaded;
    }
    void OnSceneLoaded(Scene scene, LoadSceneMode mode){
              t = GameObject.Find("Decider").GetComponent<MH_Timeline>();
        r = GameObject.Find("PanelUI").GetComponent<MH_Responses>();
        inv = GameObject.Find("Inventory").GetComponent<MH_Inventory>();
        ss = GameObject.Find("UI camera").GetComponent<MH_SetScene>();
        
        putData();
       
    }
    // Start is called before the first frame update
    void Start()
    {
              if(g == null){
                    r.progression = 0;
                    t.progression = 0;
                    ss.progression = 0;
              }
              
    }

    // Update is called once per frame
    void Update()
    {

    }
}
