using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using UnityEngine.UI;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using TMPro;
using UnityEngine.EventSystems;

public class ArrowMovement : MonoBehaviourPunCallbacks
{
    public GameObject L;
    public GameObject R;
    public GameObject RW;
    public GameObject LW;
    // public GameObject recordList;
    public int count=0;
    public int stage=0;
    public int stagec=0;
    public int canend=0;
    public int ded=0;
    public int LRed=0;
    public int mp4=0;
    public GameObject WINNER;
    public GameObject LOSER;
    public GameObject cutscene;
    public GameObject cam;
    public Text ScoreText;
    // public DataManager dm;

    // private void Awake() {
    //     dm = GameObject.Find("DataManager").GetComponent<DataManager>();
    // }
    void Update()
    {		       
        GameObject[] gosc;
        gosc = GameObject.FindGameObjectsWithTag("cutscene");
        if(gosc.Length == 2 && stagec==0)
        {  
            LW.active=false;
            count=0;
            stage=0;
            canend=0;
            ded=0;
            LRed=0;
            mp4=0;
            cam.active=true;
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
            if(photonView.IsMine)
            {
                photonView.RPC("changeD",RpcTarget.All);
            }
            // recordList.SetActive(true);
            RW.active=true;
            R.active=false;
            LRed=3;
        }

        if (Input.GetKey("a") && LRed==2)
        {
            // if(photonView.IsMine)
            // {
            //     photonView.RPC("changeD",RpcTarget.All);
            // }
            // LW.active=true;
            // L.active=false;
            // LRed=3;
        }
    }

    [PunRPC]
    void changeD()
    {
        Rigidbody rb = Instantiate(cutscene, transform.position, transform.rotation).GetComponent<Rigidbody>(); 
    }  

    public void closestart()
    {
        // DisplayRecordList();
        L.active=true;
        R.active=true;
        LRed=2;
    }   
    public void win()
    {
        WINNER.active=true;
    }  
    public void lose()
    {
        LOSER.active=true;
    } 
    // public void DisplayRecordList(){
    //     // recordList.SetActive(true);
    //     //what if only show the recent 6 record?
    //     Debug.Log("record num: " + dm.myRecordList.record.Count );
        
    //     foreach (Transform child in recordList.transform) {
    //         GameObject.Destroy(child.gameObject);
    //     }

    //     if(dm.myRecordList.record.Count >6){
    //         for(int i = dm.myRecordList.record.Count-1; i >= dm.myRecordList.record.Count-6; i--){
    //             GameObject newRecord = Instantiate<GameObject>(Resources.Load("record") as GameObject);
    //             newRecord.GetComponent<RecordSystem>().DisplayRecord(dm.myRecordList.record[i].winnerName,
    //                                                                 dm.myRecordList.record[i].loserName,
    //                                                                 dm.myRecordList.record[i].reason,
    //                                                                 dm.myRecordList.record[i].date);
    //             // newRecord.transform.parent = recordList.transform;
    //         }
    //     }
    //     else{
    //         for(int i = dm.myRecordList.record.Count-1; i >=0 ; i--){
    //             GameObject newRecord = Instantiate<GameObject>(Resources.Load("record") as GameObject);
    //             newRecord.GetComponent<RecordSystem>().DisplayRecord(dm.myRecordList.record[i].winnerName,
    //                                                                 dm.myRecordList.record[i].loserName,
    //                                                                 dm.myRecordList.record[i].reason,
    //                                                                 dm.myRecordList.record[i].date);
    //             // newRecord.transform.parent = recordList.transform;
    //         }
    //     }
    //     // for(int i = dm.myRecordList.record.Count-1; i >=0 ; i--){
    //     //     GameObject newRecord = Instantiate<GameObject>(Resources.Load("record") as GameObject);
    //     //     newRecord.GetComponent<RecordSystem>().DisplayRecord(dm.myRecordList.record[i].winnerName,
    //     //                                                         dm.myRecordList.record[i].loserName,
    //     //                                                         dm.myRecordList.record[i].reason,
    //     //                                                         dm.myRecordList.record[i].date);
    //     //     newRecord.transform.parent = recordList.transform;
    //     // }
    // }
}