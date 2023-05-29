using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.EventSystems;

public class caretColor : MonoBehaviour
{
    public TMP_InputField inputField;

    // Start is called before the first frame update
    public void ClearP()
    {
        inputField.placeholder.GetComponent<TextMeshProUGUI>().text = "";
    }
}
