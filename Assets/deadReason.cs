using UnityEngine;
using UnityEngine.UI;
using System;
using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using TMPro;
using UnityEngine.EventSystems;


public class deadReason : MonoBehaviourPunCallbacks
{
    public Text ScoreText;
    private int done=0;
    private int done2=0;
    private int done3=0;
    private int done4=0;
    private int stagec=0;
    private int f1=0;
    private int f2=0;
    private string dieby;
    private string player1;
    private int player;
    private string player2;
    private string myname;
    private string hisname;
    public GameObject user;
    public ArrowMovement ArrowMovement;
    public GameObject audioDrown;
    public GameObject audioDie;
    public GameObject audioWin;
    //  public DataManager dm;

    
    // Update is called once per frame
        
    // private void Awake() {
    //     dm = GameObject.Find("DataManager").GetComponent<DataManager>();
    // }
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
    public int replayer()
    {
        return player;
    }

    void Update()
    {	       
        GameObject[] gosc;
        gosc = GameObject.FindGameObjectsWithTag("cutscene");
        if(gosc.Length == 2 && stagec==0)
        {  
            done=0;
            done2=0;
            done3=0;
            done4=0;
            ScoreText.enabled=false;
            audioDrown.active=false;
            audioDie.active=false;
            audioWin.active=false;
			stagec=1;
		}
        if(gosc.Length == 0 && stagec==1)
        {  
			stagec=0;
		}

        GameObject[] gos;
        gos = GameObject.FindGameObjectsWithTag("Player"); 
        GameObject[] gos2;
        gos2 = GameObject.FindGameObjectsWithTag("DieReason"); 
        GameObject[] gos3;
        gos3 = GameObject.FindGameObjectsWithTag("endGame");
        GameObject[] gos4;
        gos4 = GameObject.FindGameObjectsWithTag("killer");
        string filePath1 = Application.dataPath+"/Player1name.json";
        string filePath2 = Application.dataPath+"/Player2name.json";
        if (File.Exists(filePath1))
        {
            f1=1;
        }
        else
        {
            f1=2;
        }
        if (File.Exists(filePath1))
        {
            f2=1;
        }
        else
        {
            f2=2;
        }
        if(gos.Length == 2 && done4==0)
        {
            if(gos[0].name=="player1"||gos[1].name=="player1" )
            {
                if(user.name=="player1")
                {
                    player=1;
                }            
                else
                {
                    player=2;
                } 
            }
            if(gos[0].name=="player2"||gos[1].name=="player2")
            {
                if(user.name=="player2")
                {
                    player=2;
                }            
                else
                {
                    player=1;
                } 
            }
            if(player==1 && f1==1 && f2==1)
            {
                myname=LoadFromJson1();
                hisname=LoadFromJson2();
                done4=1;
            }
            else if(player==2 && f1==1 && f2==1)
            {
                myname=LoadFromJson2();
                hisname=LoadFromJson1();
                done4=1;
            }
        }  
        if(photonView.IsMine && gos3.Length == 1 && gos4.Length == 1 && done==0)
        {
            ScoreText.enabled=true;
            if((gos2[0].name).ToString()=="RIN(Clone)")
            {
                dieby = "Craker Grenade";
            }
            else if((gos2[0].name).ToString()=="YIN(Clone)")
            {
                dieby = "Remote Grenade";
            }
            else if((gos2[0].name).ToString()=="GIN(Clone)")
            {
                dieby = "Gas Grenade";
            }
            else if((gos2[0].name).ToString()=="OIN(Clone)")
            {
                dieby = " was drowned";
            }
            done=1;
        } 
        if(photonView.IsMine && done==1 && done2==0)
        {
            if(dieby == " was drowned" && (gos3[0].name).ToString()=="player1" && player==1)
            {
                audioDrown.active=true;
                ArrowMovement.lose();
                ScoreText.text = myname+dieby;
                done2=1;

                // dm.AddRecord(hisname, myname, ScoreText.text, DateTime.Now.ToString());
            }
            else if(dieby == " was drowned" && (gos3[0].name).ToString()=="player1" && player==2)
            {
                audioWin.active=true;
                ArrowMovement.win();
                ScoreText.text = hisname+dieby;
                done2=1;

                Debug.Log(ScoreText.text);
                // dm.AddRecord(myname, hisname, ScoreText.text, DateTime.Now.ToString());
            }
            else if(dieby == " was drowned" && (gos3[0].name).ToString()=="player2" && player==2)
            {
                audioDrown.active=true;
                ArrowMovement.lose();
                ScoreText.text = myname+dieby;
                done2=1;

                Debug.Log(ScoreText.text);
                // dm.AddRecord(hisname, myname, ScoreText.text, DateTime.Now.ToString());
            }
            else if(dieby == " was drowned" && (gos3[0].name).ToString()=="player2" && player==1)
            {
                audioWin.active=true;
                ArrowMovement.win();
                ScoreText.text = hisname+dieby;
                done2=1;

                Debug.Log(ScoreText.text);
                // dm.AddRecord(myname, hisname, ScoreText.text, DateTime.Now.ToString());
            }
            else if((gos3[0].name).ToString()=="player1" && (gos4[0].name).ToString()=="player1" && player==1)
            {
                audioDie.active=true;
                ArrowMovement.lose();
                ScoreText.text = myname+" is killed by it's own "+dieby;
                done2=1;

                Debug.Log(ScoreText.text);
                // dm.AddRecord(hisname, myname, ScoreText.text, DateTime.Now.ToString());
            }
            else if((gos3[0].name).ToString()=="player2" && (gos4[0].name).ToString()=="player2" && player==1)
            {
                audioWin.active=true;
                ArrowMovement.win();
                ScoreText.text = hisname+" is killed by it's own "+dieby;
                done2=1;

                Debug.Log(ScoreText.text);
                // dm.AddRecord(myname, hisname, ScoreText.text, DateTime.Now.ToString());
            }
            else if((gos3[0].name).ToString()=="player2" && (gos4[0].name).ToString()=="player2" && player==2)
            {
                audioDie.active=true;
                ArrowMovement.lose();
                ScoreText.text = myname+" is killed by it's own "+dieby;
                done2=1;

                Debug.Log(ScoreText.text);
                // dm.AddRecord(hisname, myname, ScoreText.text, DateTime.Now.ToString());
            }
            else if((gos3[0].name).ToString()=="player1" && (gos4[0].name).ToString()=="player1" && player==2)
            {
                audioWin.active=true;
                ArrowMovement.win();
                ScoreText.text = hisname+" is killed by it's own "+dieby;
                done2=1;
                               
                Debug.Log(ScoreText.text);
                // dm.AddRecord(myname, hisname, ScoreText.text, DateTime.Now.ToString());
            }
            else if((gos3[0].name).ToString()=="player1" && (gos4[0].name).ToString()=="player2" && player==1)
            {
                audioDie.active=true;
                ArrowMovement.lose();
                ScoreText.text = myname+" is killed by "+hisname+"'s "+dieby;
                done2=1;
                                
                Debug.Log(ScoreText.text);
                // dm.AddRecord(myname, hisname, ScoreText.text, DateTime.Now.ToString());
            }   
            else if((gos3[0].name).ToString()=="player2" && (gos4[0].name).ToString()=="player1" && player==1)
            {
                audioWin.active=true;
                ArrowMovement.win();
                ScoreText.text = hisname+" is killed by "+myname+"'s "+dieby;
                done2=1;
                                
                Debug.Log(ScoreText.text);
                // dm.AddRecord(hisname, myname, ScoreText.text, DateTime.Now.ToString());
            }   
            else if((gos3[0].name).ToString()=="player1" && (gos4[0].name).ToString()=="player2" && player==2)
            {
                audioWin.active=true;
                ArrowMovement.win();
                ScoreText.text = hisname+" is killed by "+myname+"'s "+dieby;
                done2=1;
                                
                Debug.Log(ScoreText.text);
                // dm.AddRecord(myname, hisname, ScoreText.text, DateTime.Now.ToString());
            }   
            else if((gos3[0].name).ToString()=="player2" && (gos4[0].name).ToString()=="player1" && player==2)
            {
                audioDie.active=true;
                ArrowMovement.lose();
                ScoreText.text = myname+" is killed by "+hisname+"'s "+dieby;
                done2=1;
                                
                Debug.Log(ScoreText.text);
                // dm.AddRecord(hisname, myname, ScoreText.text, DateTime.Now.ToString());
            }         
        }  
    }
}
