using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RG_PolygraphTrailRenderer : MonoBehaviour
{
    private RectTransform RectTransform;
    private GameObject parent;
    [SerializeField] private float speed = 1f;
    private float a = 0f;
    private bool reverse = false;
    [SerializeField] private float floor;
    [SerializeField] private float ceiling;
    [SerializeField] float interval = .5f;
    private float x;
    // Start is called before the first frame update
    void Start()
    {
        RectTransform = GetComponent<RectTransform>();
        parent = GameObject.Find("Polygraph");
        x = RectTransform.transform.position.x;
        // RectTransform.transform.position = new Vector3 (parent.GetComponent<Transform>().position.x + (parent.GetComponent<RectTransform>().sizeDelta.x/2), 0, parent.GetComponent<Transform>().position.z);
        Debug.Log("Coordinates for polygraph: (" + parent.GetComponent<Transform>().position.x + ", " + parent.GetComponent<Transform>().position.y + ", " + parent.GetComponent<Transform>().position.z + ")");
        Debug.Log("Coordinates for graphing object: (" + RectTransform.transform.position.x + ", " + RectTransform.transform.position.y + ", " + RectTransform.transform.position.z + ")");
    }

    // Update is called once per frame
    void Update()
    {
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
        // RectTransform.transform.Translate(new Vector2(-speed, 0));
        x -= speed;
        RectTransform.transform.position = new Vector3(x, function(a), RectTransform.transform.position.z);
    }
    private float function(float a){
        // return (Mathf.Pow((3*Mathf.Sin(a)), 2f));
        return (2*Mathf.Sin(Mathf.Cos(Mathf.Pow(a*Mathf.Cos(Mathf.Pow(-1*(Mathf.Sin(3*a)), 2)), 2))));
        // return Random.value*3f;
    }
}
