using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class IsMine : MonoBehaviourPunCallbacks
{
    public GameObject camera;
    public GameObject PlayerName;
    // public GameObject player;
    public GameObject ui;
    private int done=0;
    private int done2=0;
    private int UC=0;

    // player1 vs User(Clone)
    // player2 vs User(Clone)
    void Start()
    {
        if(photonView.IsMine)
        {
            GameObject[] gos;
            gos = GameObject.FindGameObjectsWithTag("Player");   
            if(gos.Length == 1)
            {
                gameObject.name="player1";
                UC=1;
            }   
            else if(gos.Length == 2)
            {
                gameObject.name="player2";
            }   
            else if(gos.Length == 2 && gameObject.name=="User(Clone)")
            {
                gameObject.name="player1";
            }   
        }
    }

    void Update()
    {
        if(photonView.IsMine)
        {
            camera.SetActive(true);
            // player.SetActive(true);
            ui.SetActive(true);
        }
        else
        {
            camera.SetActive(false);
            // player.SetActive(false);
            ui.SetActive(false);
        }
		// photonView.RPC("InstantiatePlayerName",RpcTarget.All); 
    }

    // [PunRPC]
    // void InstantiatePlayerName()
    // {
    //     GameObject[] gos2;
    //     gos2 = GameObject.FindGameObjectsWithTag("PlayerName"); 
    //     GameObject[] gos1;
    //     gos1 = GameObject.FindGameObjectsWithTag("Player");   
    //     if(gos1.Length==2 && done2==0)
    //     {
    //         Rigidbody rb = Instantiate(PlayerName, transform.position, transform.rotation).GetComponent<Rigidbody>();
    //         rb.name=gos2[0].name;
    //         print(rb.name);
    //         done2=1;
    //     }
    // }
    
}
