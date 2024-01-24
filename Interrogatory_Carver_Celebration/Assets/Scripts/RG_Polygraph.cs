using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RG_Polygraph : MonoBehaviour
{
    [SerializeField] private GameObject prefab;
    private RectTransform rectTransform;
    private float a = 0f;
    private float b;
    [SerializeField] float interval = .5f;
    float time = 0.0f;
    int seconds = 0;
    private bool reverse = false;
    [SerializeField] private float floor;
    [SerializeField] private float ceiling;
    [SerializeField] private float speed = 1f;
    [SerializeField] private float scalar = 1f;
    GameObject graphingPrefab;
    Transform transform;
    // Start is called before the first frame update
    void Start()
    {
        rectTransform = GetComponent<RectTransform>();
        floor = -3f;
        ceiling = 3f;
        transform = GetComponent<Transform>();
        // transform.position = new Vector3(rectTransform.transform.position.x, function(a), 55.6f);
        // Instantiate(prefab, new Vector3(rectTransform.transform.position.x, function(3f, 1f), 55.6f), Quaternion.identity, gameObject.transform.parent);
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        if(time >= interval){
        //     seconds++;
            // // increases and decreases interval in between a floor and ceiling value (separate from worry meter)
            // if(a < ceiling && a > floor && !reverse){
            //     a += interval;
            // }
            // else if(a < ceiling && a > floor && reverse){
            //     a -= interval;
            // }
            // else if(a >= ceiling){
            //     reverse = !reverse;
            //     a -= interval;
            // }
            // else if(a <= floor){
            //     reverse = !reverse;
            //     a += interval;
            // }
            // // increases interval to show graph seperate from worry meter
            // a += interval;
            // if(a > ceiling){
            //     a = floor;
            // }
            // //code from trail-renderer implementation; defunct in instantiating particle implementation
            // if(transform.localPosition.x >= 0){
            //     rectTransform.transform.Translate(new Vector2(-speed, 0));
            // }
            // Debug.Log("height: " + (rectTransform.transform.position.y-(rectTransform.sizeDelta.y/2)) + " " + rectTransform.transform.position.y + " " + rectTransform.sizeDelta.y/2);
                graphingPrefab = (GameObject)Instantiate(prefab, new Vector3(rectTransform.transform.position.x, function(GameObject.Find("PanelUI").GetComponent<MH_Responses>().worryMeter) + 44, 55.6f), Quaternion.identity, gameObject.transform.parent);
                graphingPrefab.transform.SetParent(GameObject.Find("Polygraph").GetComponent<Transform>());
            time = 0f;
            Debug.Log(a);
        }
    }

    // a collection of different mathematical function to graph on the polygraph
    private float function(float a){
        // return (Mathf.Pow((3*Mathf.Sin(a)), 2f));
        // return ((Mathf.Pow(a, 4f)/3f)+(2*Mathf.Pow(a, 3f))-(6*a)-3)/scalar;
        // return (((5*Mathf.Pow(a, 3f))-(20*a)-3)/scalar);
        // return Mathf.Pow(2f, a-1);
        return 4*Mathf.Cos(a)+1;
        // return (2*Mathf.Sin(Mathf.Cos(Mathf.Pow(a*Mathf.Cos(Mathf.Pow(-1*(Mathf.Sin(3*a)), 2)), 2))));
        // return Random.value*3f;
    }

    // setters and getters for A, but not needed because A was used for testing purposes only
    void  setA(float a){
        this.a = a;
    }
    void  setB(float b){
        this.b = b;
    }
    float getA(){
        return a;
    }
    float getB(){
        return b;
    }
}
