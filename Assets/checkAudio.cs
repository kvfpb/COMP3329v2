using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class checkAudio : MonoBehaviour
{
    public GameObject aus;
    public GameObject aug;
    public GameObject start;
    // Update is called once per frame
    void Update()
    {
        if(start.active==true)
        {
            aus.active=true;
            aug.active=false;
        }
        else if(start.active==false)
        {
            aus.active=false;
            aug.active=true;
        }
        
    }
}
