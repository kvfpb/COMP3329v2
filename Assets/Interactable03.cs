using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class Interactable03 : MonoBehaviourPunCallbacks
{
    public GameObject theSupply3;
    public GameObject Object003;
    public void active3()
    {   
        photonView.RPC("active3rpc",RpcTarget.All);
    }

    [PunRPC] 
    public void active3rpc()
    {   
        Object003.GetComponent<MeshCollider>().enabled=true;
        theSupply3.GetComponent<Animation>().Play("Crate_Open");
    }

}
