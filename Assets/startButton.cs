using UnityEngine;
using UnityEngine.UI;
using System;
using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using TMPro;
using UnityEngine.EventSystems;

public class startButton : MonoBehaviourPunCallbacks
{
    public GameObject startScene; 
    public GameObject AL;
    public GameObject errortext;
    public GameObject waitplayer;
    public GameObject waitscene;
    public TMP_InputField playername;
    public GameObject cutscene;
    public int stage=0;
    public int rename=0;
    public int killby=0;
    public int startGame=0;
    public int clean=0;
    public Canvas UI;
    public Canvas waitUI;
    public Image UImage;
    public GameObject UIplace;
// ==========================================================================================
    public void Update()
    {
        GameObject[] gos;
        gos = GameObject.FindGameObjectsWithTag("Player");
        string filePath1 = Application.dataPath+"/Player1name.json";
        if(gos.Length == 1 && clean==0)
        { 
            if(File.Exists(filePath1))
            {
                photonView.RPC("ReceiveJsonData", RpcTarget.All);
                clean=1;
            }
        }
        if(PhotonNetwork.PlayerList.Length==2)
        {
            waitplayer.active=false;
        }
        // ========================================================
        GameObject[] gos2;
        gos2 = GameObject.FindGameObjectsWithTag("cutscene");  
        if(gos2.Length == 2 && stage==0)
        {
            waitscene.active=false;
            // waitUI.enabled=false;
            rename=0;
            stage=1;
        }
        if(gos2.Length == 0 && stage==1)
        {
            stage=0;
        }

        if(rename==1)
        {
            waitscene.active=true;
            // waitUI.enabled=true;
        }
    }
// ==========================================================================================
    [PunRPC]
    private void ReceiveJsonData()
    {
        playername.text = "";
    }
// ==========================================================================================
    public void StartGame()
    {
        // print(playername.text);
        if(playername.text!="" && PhotonNetwork.PlayerList.Length==2)
        {
            GameObject[] gos;
            gos = GameObject.FindGameObjectsWithTag("Player");  
            if(gos.Length > 2)
            {
                rename=1;
                photonView.RPC("changeD",RpcTarget.All);
                // UI.enabled=false;
                // startScene.active=false;
                Invoke("closestart",1f);
            }
            else if(gos.Length == 1)
            {
                string filePath1 = Application.dataPath+"/Player1name.json";
                if(File.Exists(filePath1))
                {
                    if(playername.text==LoadFromJson1())
                    {
                        errortext.active=true;
                    }
                    else if(playername.text!=LoadFromJson1())
                    {
                        errortext.active=false;
                        AL.GetComponent<AudioListener>().enabled = false;
                        Invoke("closestart",1f);
                        // closestart();
                        startGame=1;
                    }
                }
            }
            else
            {
                errortext.active=false;
                AL.GetComponent<AudioListener>().enabled = false;
                Invoke("closestart",1f);
                // closestart();
                startGame=1;
            }
        }   
        else if(PhotonNetwork.PlayerList.Length<2)
        {
            waitplayer.active=true;
        }
    }
// ==========================================================================================
    [PunRPC]
    void changeD()
    {
        Rigidbody rb = Instantiate(cutscene, transform.position, transform.rotation).GetComponent<Rigidbody>(); 
    } 
// ==========================================================================================
    public string LoadFromJson1()
    {
        string json = File.ReadAllText(Application.dataPath + "/Player1name.json");
        jsond data = JsonUtility.FromJson<jsond>(json);
        return data.playername;
    }   
    public string LoadFromJson2()
    {
        string json = File.ReadAllText(Application.dataPath + "/Player2name.json");
        jsond data = JsonUtility.FromJson<jsond>(json);
        return data.playername;
    }  
    public void closestart()
    {
        UImage.enabled=false;
        UIplace.active=false;
        // UI.enabled=false;
        startScene.active=false;
    }

}
