using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class countPlayer : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        GameObject[] gos;
        gos = GameObject.FindGameObjectsWithTag("Player");
        if(gos.Length == 1)
        {
            print("1");
        }     
        else if(gos.Length == 2)
        {
            print("2");
        }   
    }
}
