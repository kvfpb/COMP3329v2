using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class interactToPlater : MonoBehaviourPunCallbacks
{
    // private int SupplyState=1;
    // public GameObject theSupplytest;
    // public GameObject Object001test;
    //==================================
    private void Update()
    {
        // if (photonView.IsMine)
        // {
        //     if(Input.GetKeyDown(KeyCode.F))
        //     {
        //         float interactRange = 1f;
        //         Collider[] colliderArray2 = Physics.OverlapSphere(transform.position, interactRange);
        //         foreach(Collider collider2 in colliderArray2)
        //         {
        //             if (collider2.TryGetComponent(out openSupply openSupply) && SupplyState==1)
        //             {
        //                 // photonView.RPC("opensupplynow",RpcTarget.All);
        //                 SupplyState=0;
        //                 Object001test.GetComponent<MeshCollider>().enabled=true;
        //                 theSupplytest.GetComponent<Animation>().Play("Crate_Open");
        //             }        
        //         }
        //     }
        // }
    }
    
    // [PunRPC] 
    // public void opensupplynow()
    // {
    //     SupplyState=0;
    //     Object001test.GetComponent<MeshCollider>().enabled=true;
    //     theSupplytest.GetComponent<Animation>().Play("Crate_Open");
    // }
}
