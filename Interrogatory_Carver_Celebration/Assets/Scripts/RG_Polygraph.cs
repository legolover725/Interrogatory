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
    GameObject graphingPrefab;
    // Start is called before the first frame update
    void Start()
    {
        rectTransform = GetComponent<RectTransform>();
        floor = -3f;
        ceiling = 3f;
        // Instantiate(prefab, new Vector3(rectTransform.transform.position.x, function(3f, 1f), 55.6f), Quaternion.identity, gameObject.transform.parent);
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        if(time >= interval){
        //     seconds++;
            // a += (float)GameObject.Find("PanelUI").GetComponent<MH_Responses>().suspicionMeter;
            if(a < ceiling && a > floor && !reverse){
                a += interval;
            }
            else if(a < ceiling && a > floor && reverse){
                a -= interval;
            }
            else if(a >= ceiling){
                reverse = !reverse;
                a -= interval;
            }
            else if(a <= floor){
                reverse = !reverse;
                a += interval;
            }
            // Debug.Log("height: " + (rectTransform.transform.position.y-(rectTransform.sizeDelta.y/2)) + " " + rectTransform.transform.position.y + " " + rectTransform.sizeDelta.y/2);
            // if(function(a) >= floor && function(a) <= ceiling){
                graphingPrefab = (GameObject)Instantiate(prefab, new Vector3(rectTransform.transform.position.x, function(a) + 44, 55.6f), Quaternion.identity, gameObject.transform.parent);
                graphingPrefab.transform.SetParent(GameObject.Find("Polygraph").GetComponent<Transform>());
            // }
            time = 0f;
            Debug.Log(a);
        }
    }

    private float function(float a){
        // return (Mathf.Pow((3*Mathf.Sin(a)), 2f));
        return (2*Mathf.Sin(Mathf.Cos(Mathf.Pow(a*Mathf.Cos(Mathf.Pow(-1*(Mathf.Sin(3*a)), 2)), 2))));
        // return Random.value*3f;
    }

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
