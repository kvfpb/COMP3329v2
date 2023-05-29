using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.EventSystems;

public class namer : MonoBehaviour
{
    public TMP_InputField inputField;
    public GameObject PlayerName;
    public int done=0;
    public int done2=0;
    public int done3=0;
    public int player=0;

    void Update()
    {
        GameObject[] gos;
        gos = GameObject.FindGameObjectsWithTag("Player");   
        if(gos.Length == 1 && done==0)
        {
            player=1;
            done=1;
        }   
        else if(gos.Length == 2 && done==0)
        {
            player=2;
            done=1;
        } 

        if(player == 1 && done2==0)
        {
            Rigidbody rb = Instantiate(PlayerName, transform.position, transform.rotation).GetComponent<Rigidbody>();
            rb.name=inputField.text+"1";
            // print(1);
            // print(rb.name);
            done2=1;
        }   
        if(player == 2 && done3==0)
        {
            Rigidbody rb = Instantiate(PlayerName, transform.position, transform.rotation).GetComponent<Rigidbody>();
            rb.name=inputField.text+"2";
            // print(2);
            // print(rb.name);
            done3=1;
        } 
    }
}
