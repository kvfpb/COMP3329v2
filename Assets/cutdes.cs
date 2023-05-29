using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class cutdes : MonoBehaviourPunCallbacks
{
    public Canvas UI;
    public GameObject text;
    public GameObject EndUI1;
    public GameObject EndUI2;
    public GameObject EndUI3;
    public GameObject EndUI4;
    public GameObject EndUI5;
    public GameObject playerr;
    // public GameObject EndUIRecord;
    public GameObject remote1;
    public GameObject remote2;
    public GameObject remote3;
    public int stage=0;
    public deadReason deadReason;
    private System.Random random;
    // Update is called once per frame
    void Update()
    {        
        GameObject[] gos2;
        gos2 = GameObject.FindGameObjectsWithTag("cutscene");
        if(gos2.Length == 2 && stage==0)
        {
            Debug.Log("DOCUTSCENE");
            UI.enabled=false;
            EndUI1.active=false;
            EndUI2.active=false;
            EndUI3.active=false;
            EndUI4.active=false;
            EndUI5.active=false;
            // EndUIRecord.active = false;

            int player = deadReason.replayer();
            if(player==1)
            {
                if(photonView.IsMine)
                {
                    print("player1");
                    photonView.RPC("tran1",RpcTarget.All);
                }
            }
            if(player==2)
            {
                if(photonView.IsMine)
                {
                    print("player2");
                    photonView.RPC("tran2",RpcTarget.All);
                }
            }
            stage=1;

            // if(remote1.GetComponent<GrenadeY>().CanExplode == 1){
            //     // remote1.GetComponent<GrenadeY>().RemoteGrenade.active=false;
            // }
            remote1.GetComponent<GrenadeY>().Reset();

            remote2.GetComponent<GrenadeY2>().Reset();

            remote3.GetComponent<GrenadeY3>().Reset();
        }
        else if(gos2.Length == 0 && stage==1)
        {
            UI.enabled=true;
            stage=0;
        }
    }

    [PunRPC] 
    public void tran1()
    {
        Rigidbody rb = playerr.GetComponent<Rigidbody>(); 
        random = new System.Random((int)System.DateTime.Now.Ticks);
        int randomNumber = random.Next(1, 5);
        if(randomNumber==1)
        {
            rb.position= new Vector3(-175,-5,75);
            remote1.GetComponent<Rigidbody>().position = new Vector3(-175,-5,75);
            remote2.GetComponent<Rigidbody>().position = new Vector3(-175,-5,75);
            remote3.GetComponent<Rigidbody>().position = new Vector3(-175,-5,75);
        }
        else if(randomNumber==2)
        {
            rb.position= new Vector3(-183.7f,-4,120.6f);
            remote1.GetComponent<Rigidbody>().position = new Vector3(-183.7f,-4,120.6f);
            remote2.GetComponent<Rigidbody>().position = new Vector3(-183.7f,-4,120.6f);
            remote3.GetComponent<Rigidbody>().position = new Vector3(-183.7f,-4,120.6f);
        }
        else if(randomNumber==3)
        {
            rb.position= new Vector3(-135, 10, 187);
            remote1.GetComponent<Rigidbody>().position = new Vector3(-135, 10, 187);
            remote2.GetComponent<Rigidbody>().position = new Vector3(-135, 10, 187);
            remote3.GetComponent<Rigidbody>().position = new Vector3(-135, 10, 187);
        }
        else
        {
            rb.position= new Vector3(-168, 4, 159);
            remote1.GetComponent<Rigidbody>().position = new Vector3(-168, 4, 159);
            remote2.GetComponent<Rigidbody>().position = new Vector3(-168, 4, 159);
            remote3.GetComponent<Rigidbody>().position = new Vector3(-168, 4, 159);
        }
    }

    [PunRPC] 
    public void tran2()
    {
        Rigidbody rb = playerr.GetComponent<Rigidbody>(); 
        random = new System.Random((int)System.DateTime.Now.Ticks);
        int randomNumber = random.Next(1, 5);
        if(randomNumber==1)
        {
            rb.position= new Vector3(-128,-6,68);
        }
        else if(randomNumber==2)
        {
            rb.position= new Vector3(-140,-5,105);
        }
        else if(randomNumber==3)
        {
            rb.position= new Vector3(-95.5f,8.5f,150);
        }
        else
        {
            rb.position= new Vector3(-102,1,117);
        }
    }
}
