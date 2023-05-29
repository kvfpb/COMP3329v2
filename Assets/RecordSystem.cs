using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class RecordSystem : MonoBehaviour
{
    public Text winnerName;
    public Text loserName;
    public Text deathReason;
    public Text date;

    public void DisplayRecord(string RwinnerName, string RloserName, string Rreason, string Rdate){
        winnerName.text = RwinnerName;
        loserName.text = RloserName;
        deathReason.text = Rreason;
        date.text = Rdate;
    }
}