// using System.Collections;
// using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using Photon.Pun;

public class grenadeNumber : MonoBehaviourPunCallbacks
{
    public Text ScoreText;
    public int count = 10;
    // Update is called once per frame
    void Update()
    {
        if (photonView.IsMine)
        {        
            if(count<10)
            {
                ScoreText.text = " "+(count).ToString("0");
            }
            else if(count>99)
            {
                count=99;
                ScoreText.text = (count).ToString("0");
            }
            else
            {
                ScoreText.text = (count).ToString("0");
            }
        }
    }
}