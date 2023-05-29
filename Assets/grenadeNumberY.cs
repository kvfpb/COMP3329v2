using UnityEngine;
using UnityEngine.UI;
using System;
using Photon.Pun;

public class grenadeNumberY : MonoBehaviourPunCallbacks
{
    public Text ScoreText;
    public string count = " 1";
    public GameObject box1;
    public GameObject box2;
    public GameObject box3;
    public GameObject boxnum;
    // Update is called once per frame
    void Update()
    {
        if (photonView.IsMine)
        {        
            if(count == " 1")
            {
                ScoreText.text = " 1";
                box1.active=false;
                box2.active=false;
                box3.active=false;
                boxnum.active=false;
            }
            else if(count == " R")
            {
                ScoreText.text = "";
                // box1.active=true;
                // box2.active=true;
                // box3.active=true;
                // boxnum.active=true;
            }
            else if(count == " 0")
            {
                ScoreText.text = " 0";
                box1.active=false;
                box2.active=false;
                box3.active=false;
                boxnum.active=false;
            }
        } 
    }
}
