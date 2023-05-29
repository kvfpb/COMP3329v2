using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestoryWhenCut : MonoBehaviour
{   
    void Update()
    {
        GameObject[] gos2;
        gos2 = GameObject.FindGameObjectsWithTag("cutscene");  
        if(gos2.Length == 2)
        {
            Destroy(gameObject);
        }
        
    }
}
