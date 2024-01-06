using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RG_PolygraphShifter : MonoBehaviour
{
    private RectTransform rectTransform;
    [SerializeField] private float speed = 1f;
    private float originalX;
    // Start is called before the first frame update
    void Start()
    {
        rectTransform = GetComponent<RectTransform>();
        originalX = rectTransform.transform.position.x;
    }

    // Update is called once per frame
    void Update()
    {
        rectTransform.transform.Translate(new Vector2(-speed, 0));
        // Debug.Log("current x: " + rectTransform.transform.position.x + "\n Width of parent: " + GameObject.Find("Polygraph").GetComponent<RectTransform>().sizeDelta.x + "\n Original x: " +  + originalX);
        // Debug.Log("local position: " + GetComponent<Transform>().localPosition.x + "\nparent name: " + GetComponent<Transform>().parent.name);
        if(Mathf.Abs(GetComponent<Transform>().localPosition.x) > GameObject.Find("Polygraph").GetComponent<RectTransform>().sizeDelta.x){
            Destroy(this.gameObject);
        }
    }
}
