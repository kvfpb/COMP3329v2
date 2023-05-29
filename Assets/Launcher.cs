using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using System.IO;

public class Launcher : MonoBehaviourPunCallbacks
{
    public PhotonView playerPrefab;
    private int stopconnect=0;
    private int player=0;
    private int player2=0;
    private int joined=0;
    private int stage=0;
    private int f1=0;
    private int f2=0;
    public int canend=0;
    public startButton startButton;
    public GameObject Crosshir;
    private System.Random random;

    // Start is called before the first frame update
    void Start()
    {
        string filePath1 = Application.dataPath+"/Player1name.json";
        string filePath2 = Application.dataPath+"/Player2name.json";
        if (File.Exists(filePath1))
        {
            // Delete the file
            File.Delete(filePath1);
            Debug.Log("File1 deleted successfully");
        }
        else
        {
            Debug.Log("File1 does not exist");
        }
        if (File.Exists(filePath2))
        {
            // Delete the file
            File.Delete(filePath2);
            Debug.Log("File2 deleted successfully");
        }
        else
        {
            Debug.Log("File2 does not exist");
        }
        PhotonNetwork.ConnectUsingSettings(); 
        player=0;       
    }

    private void Update()
    {      
        string filePath1 = Application.dataPath+"/Player1name.json";
        string filePath2 = Application.dataPath+"/Player2name.json";
        GameObject[] gos1;
        gos1 = GameObject.FindGameObjectsWithTag("Player");
        if (File.Exists(filePath1))
        {
            f1=1;
        }
        else
        {
            f1=2;
        }
        if(joined==1 && player==0 && startButton.startGame==1 && gos1.Length == 0)
        {
            random = new System.Random((int)System.DateTime.Now.Ticks);
            int randomNumber = random.Next(1, 5);
            if(randomNumber==1)
            {
                PhotonNetwork.Instantiate(playerPrefab.name, new Vector3(-175,-5,75), Quaternion.identity);
            }
            else if(randomNumber==2)
            {
                PhotonNetwork.Instantiate(playerPrefab.name, new Vector3(-183.7f,-4,120.6f), Quaternion.identity);
            }
            else if(randomNumber==3)
            {
                PhotonNetwork.Instantiate(playerPrefab.name, new Vector3(-135, 10, 187), Quaternion.identity);
            }
            else 
            {
                PhotonNetwork.Instantiate(playerPrefab.name, new Vector3(-168, 4, 159), Quaternion.identity);        
            }
            player=1;
            Crosshir.active = true; 
        }  
        if(joined==1 && player==0 && startButton.startGame==1 && gos1.Length == 1 && f1==1)
        {
            random = new System.Random((int)System.DateTime.Now.Ticks);
            int randomNumber = random.Next(1, 5);
            if(randomNumber==1)
            {
                PhotonNetwork.Instantiate(playerPrefab.name, new Vector3(-128,-6,68), Quaternion.identity);
            }
            else if(randomNumber==2)
            {
                PhotonNetwork.Instantiate(playerPrefab.name, new Vector3(-140,-5,105), Quaternion.identity);
            }
            else if(randomNumber==3)
            {
                PhotonNetwork.Instantiate(playerPrefab.name, new Vector3(-95.5f,8.5f,150), Quaternion.identity);
            }
            else 
            {
                PhotonNetwork.Instantiate(playerPrefab.name, new Vector3(-102,1,117), Quaternion.identity);
            }
            player=1;
            Crosshir.active = true; 
        }   
    }

    public override void OnConnectedToMaster()
    {
        //we connected
        Debug.Log("Connected to Master");
        PhotonNetwork.JoinRandomOrCreateRoom();
    }

    public override void OnJoinedRoom()
    { 
        Debug.Log("Joined a room successfully!");  
        joined=1; 
        Debug.Log("Joined room: " + PhotonNetwork.CurrentRoom.Name);
    }
}
