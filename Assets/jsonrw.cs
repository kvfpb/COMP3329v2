using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.EventSystems;
using Photon.Pun;
using System;

public class jsonrw : MonoBehaviourPunCallbacks 
{
    public TMP_InputField idInputField;
    private int done=0;
    private int done1=0;
    private int done2=0;
    private int done3=0;
    private int done4=0;
    private int verydone=0;
    private PhotonView photonView;
    public int player=0;
    public int stagec=0;
    public int LRed=0;
    public int donee=0;
    public int donev1=0;
    public int donev2=0;
    public int pressPlayer=0;    
    public GameObject rename;
// ==========================================================================================
    void Awake()
    {
        photonView = GetComponent<PhotonView>();
    }
// ==========================================================================================
    public void Update()
    {
        GameObject[] gos;
        gos = GameObject.FindGameObjectsWithTag("Player");
        if(done==0)
        {
            if(gos.Length == 1)
            {
                jsond data = new jsond();
                data.playername =  idInputField.text;
                if(idInputField.text!="")
                {
                    string json = JsonUtility.ToJson(data, true);
                    File.WriteAllText(Application.dataPath+"/Player1name.json", json);
                    photonView.RPC("ReceiveJsonData", RpcTarget.Others, json);
                    done=1;
                }
            } 
        }
        if(done2==0)
        {
            if(gos.Length == 2)
            {
                jsond data2 = new jsond();
                data2.playername =  idInputField.text;
                if(idInputField.text!="")
                {
                    string json2 = JsonUtility.ToJson(data2, true);
                    File.WriteAllText(Application.dataPath+"/Player2name.json", json2);
                    photonView.RPC("ReceiveJsonData", RpcTarget.Others, json2);
                    done2=1;
                }
            } 
        }     
        // ===========================================================================
        GameObject[] gos2; 
        gos2 = GameObject.FindGameObjectsWithTag("endGame"); 
        if(gos2.Length > 0  && donee==0)
        {
            Invoke("LRed1",3);                      
            donee=1;                                
        }                                           
        if (Input.GetKey("a") && LRed==1)
        {
            // photonView.RPC("renameObject", RpcTarget.All);
            // if(gos[0].name=="player1"||gos[1].name=="player1") //bug
            // {
            //     photonView.RPC("RenamePlayer1", RpcTarget.All);
            // }
            // if(gos[0].name=="player2"||gos[1].name=="player2") //bug
            // {
            //     photonView.RPC("RenamePlayer2", RpcTarget.All);
            // }
            // LRed=2;
        }  
        if(done3==0)
        {
            if(gos.Length == 3)
            {
                jsond data2 = new jsond();
                data2.playername =  idInputField.text;
                if(idInputField.text!="")
                {
                    string json2 = JsonUtility.ToJson(data2, true);
                    if(pressPlayer==1)
                    {
                        File.WriteAllText(Application.dataPath+"/Player1name.json", json2);
                    }
                    else if(pressPlayer==2)
                    {
                        File.WriteAllText(Application.dataPath+"/Player2name.json", json2);
                    }
                    photonView.RPC("ReceiveJsonData", RpcTarget.Others, json2);
                    done3=1;
                }
            } 
        } 
        if(done4==0)
        {
            if(gos.Length == 4)
            {
                jsond data2 = new jsond();
                data2.playername =  idInputField.text;
                if(idInputField.text!="")
                {
                    string json2 = JsonUtility.ToJson(data2, true);
                    if(pressPlayer==1)
                    {
                        File.WriteAllText(Application.dataPath+"/Player1name.json", json2);
                    }
                    else if(pressPlayer==2)
                    {
                        File.WriteAllText(Application.dataPath+"/Player2name.json", json2);
                    }
                    photonView.RPC("ReceiveJsonData", RpcTarget.Others, json2);
                    done4=1;
                }
            } 
        }
        // ===========================================================================
        GameObject[] gosc;
        gosc = GameObject.FindGameObjectsWithTag("cutscene");
        if(gosc.Length == 2 && stagec==0)
        {  
            LRed=1;                                     
            done3=0;                                   
            done4=0;                                   
			stagec=1;
		}
        if(gosc.Length == 0 && stagec==1)
        {  
			stagec=0;
		}
    }  
// ==========================================================================================
    public void LRed1()
    {
        LRed=1;
    }                                       // xxxxxxxxxxxxxxxxxxxxx
                                            // xxxxxxxxxxxxxxxxxxxxx
    public int LRed3()                      // xxxxxxxxxxxxxxxxxxxxx
    {
        return LRed;
    }
// ==========================================================================================
    [PunRPC]
    private void ReceiveJsonData(string jsonData)
    {
        jsond data = JsonUtility.FromJson<jsond>(jsonData);
        idInputField.text = data.playername;
    }

    [PunRPC]
    private void RenamePlayer1()
    {
        pressPlayer=1;                      // xxxxxxxxxxxxxxxxxxxxx
    }                                       // xxxxxxxxxxxxxxxxxxxxx
                                            // xxxxxxxxxxxxxxxxxxxxx
    [PunRPC]
    private void RenamePlayer2()
    {
        pressPlayer=2;
    }

    [PunRPC]
    private void renameObject()
    {
        Rigidbody rb = Instantiate(rename, transform.position, transform.rotation).GetComponent<Rigidbody>(); 
    }
}