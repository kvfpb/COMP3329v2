using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class controlCut : MonoBehaviour
{
    public GameObject cutscene;
    public GameObject crosshair;
    public int stage=0;
    
    void Update()
    {
        GameObject[] gos2;
        gos2 = GameObject.FindGameObjectsWithTag("cutscene");  
        if(gos2.Length == 2 && stage==0)
        {
            cutscene.active=true;
            crosshair.active=false;
            Invoke("des",3);
            stage=1;
        }
        if(gos2.Length == 0 && stage==1)
        {
            stage=0;
        }
    }
    void des()
    {
        cutscene.active=false;
        crosshair.active=true;
    }
}
