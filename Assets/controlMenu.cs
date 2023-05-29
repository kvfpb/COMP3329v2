using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class controlMenu : MonoBehaviourPunCallbacks
{
    public GameObject CtMenu;
    public int stage=0;
    // Update is called once per frame
    void Update()
    {
        GameObject[] gos;
        gos = GameObject.FindGameObjectsWithTag("endGame");
        GameObject[] gos2;
        gos2 = GameObject.FindGameObjectsWithTag("cutscene");
        if(gos2.Length != 0)
        {
            CtMenu.active=false;
            stage=0;
        }
        else if (photonView.IsMine && gos.Length == 0 && stage==0)
        {
            if (Input.GetKey(KeyCode.Tab))
            {
                CtMenu.active=true;
            }
            else
            {
                CtMenu.active=false;
            }
        }
        else if(gos.Length > 0)
        {
            CtMenu.active=false;
            stage=1;
        }
    }
}
