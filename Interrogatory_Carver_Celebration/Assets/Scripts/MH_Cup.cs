using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MH_Cup : MonoBehaviour
{
    public GameObject prefab;

    public Vector3 spawnPoint;

    public void spawnCup(){
        GameObject o = (GameObject)Instantiate(prefab, spawnPoint,transform.rotation);
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
