using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class Interactable02 : MonoBehaviourPunCallbacks
{
    public GameObject theSupply2;
    public GameObject Object002;
    public void active2()
    {   
        photonView.RPC("active2rpc",RpcTarget.All);
    }

    [PunRPC] 
    public void active2rpc()
    {   
        Object002.GetComponent<MeshCollider>().enabled=true;
        theSupply2.GetComponent<Animation>().Play("Crate_Open");
    }    
}
