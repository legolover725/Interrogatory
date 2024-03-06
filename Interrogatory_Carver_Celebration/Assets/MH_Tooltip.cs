using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MH_Tooltip : MonoBehaviour
{
        [TextAreaAttribute]
    public List<string> tutorialOption = new List<string>();
    int p;

    public void appearTooltip(){
        StartCoroutine(tooltipLife());
    }

    public IEnumerator tooltipLife(){
        GetComponent<CanvasGroup>().alpha = 1;
        transform.GetChild(0).GetComponent<Text>().text = tutorialOption[p];
        p++;
        yield return new WaitForSeconds(7f);
        GetComponent<CanvasGroup>().alpha = 0;

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
