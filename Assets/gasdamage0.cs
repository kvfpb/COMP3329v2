using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using System;

// User -> PlayerCam
public class gasdamage0 : MonoBehaviourPunCallbacks
{
    private int dead=0;
    private int stagec=0;
    private int barriering=0; //#187
    private float interactRange = 6f;
    public DestructibleP destP;
    // public startButton startButton;

    void Update()
    {
        GameObject[] gosc;
        gosc = GameObject.FindGameObjectsWithTag("cutscene");
        if(gosc.Length == 2 && stagec==0)
        {  
            dead=0;
			stagec=1;
		}
        if(gosc.Length == 0 && stagec==1)
        {  
			stagec=0;
		}
        // Gas damage
        Collider[] colliderArray2 = Physics.OverlapSphere(transform.position, interactRange);
        foreach(Collider collider2 in colliderArray2)
        {
            if (collider2.TryGetComponent(out gasdamage gasdamage) )
            {
                barriering=destP.gasbarrier(); //#187
                if (dead==0 && collider2.name=="player1" && barriering==0) //#187
                {
                    dead=1;
                    destP.killbyG1();
                }
                else if (dead==0 && collider2.name=="player2" && barriering==0) //#187
                {
                    dead=1;
                    destP.killbyG2();
                }
            }
        }    
    }

    // [PunRPC]
    // void Dy()
    // {
    //     // print(collider2.name);
    //     print("1.1");
    //     // dead=1;
    //     destP.killbyG();
    //     destP.Destroy();
    // }

    // [PunRPC]
    // void SDy()
    // {
    //     // print(collider2.name);
    //     print("1.2");
    //     // dead=1;
    //     destP.killbyG();
    //     destP.selfDestroy();
    // }

	// void OnTriggerExit(Collider other) 
    // {
	// 	if(other.transform.name=="Sphere8" && dead==0)
    //     {
    //         dead=1;
    //         // startButton.killbyG();
    //         destP.killbyG();
    //         destP.Destroy();
	// 	}
    // }
}
