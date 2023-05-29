using UnityEngine;
using UnityEngine.UI;
using System;
using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using TMPro;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class rename : MonoBehaviour
{
    public int LRed=0;
    public Canvas UI;
    public Image UImage;
    public GameObject UIplace;
    public GameObject startScene;
    public int stagec=0;
    void Update()
    {       
        GameObject[] gosc;
        gosc = GameObject.FindGameObjectsWithTag("cutscene"); 
        GameObject[] gosp;
        gosp = GameObject.FindGameObjectsWithTag("Player");  
        // if(gosc.Length == 2 && LRed==4)
        // {
        //     if(gosp[0].name=="player1"||gosp[1].name=="player1")
        //     {
        //         Invoke("rename0",3);
        //     }
        //     else
        //     {
        //         Invoke("rename0",2);
        //     }
        // }  
        if(gosc.Length == 2 && stagec==0)
        {  
            LRed=0;
			stagec=1;
		}
        if(gosc.Length == 0 && stagec==1)
        {  
			stagec=0;
		}

        GameObject[] gos;
        gos = GameObject.FindGameObjectsWithTag("endGame"); 
        if(gos.Length == 0)
        {
        }
        else
        {
            if(LRed==0)
            {
                Invoke("closestart",3);
                LRed=1;
            }
        }  

        if (Input.GetKey("d") && LRed==2)
        {
        }    
        if (Input.GetKey("a") && LRed==2)
        {
            // Application.Quit();
            // rename0();
            // LRed=4;
        }  
    }
    public void closestart()
    {
        LRed=2;
    } 
    public void rename0()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        PhotonNetwork.Disconnect();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }    


}
