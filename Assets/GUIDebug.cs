using UnityEngine;
using System.Collections;

public class GUIDebug : MonoBehaviour
{
    uint qsize = 20;  // number of messages to keep
    Queue myLogQueue = new Queue();
    void Start() {
        Debug.Log("Started up logging. To disable, remove GUIDebug.cs component from 'arean'");
    }

    void OnEnable() {
        Application.logMessageReceived += HandleLog;
    }

    void OnDisable() {
        Application.logMessageReceived -= HandleLog;
    }

    void HandleLog(string logString, string stackTrace, LogType type) {
        myLogQueue.Enqueue("[" + type + "] : " + logString);
        if (type == LogType.Exception)
            myLogQueue.Enqueue(stackTrace);
        while (myLogQueue.Count > qsize)
            myLogQueue.Dequeue();
    }

    void OnGUI() {
        GUILayout.BeginArea(new Rect(Screen.width - 400, 0, 400, Screen.height));
        GUI.contentColor = Color.black;
        GUILayout.Label("\n" + string.Join("\n", myLogQueue.ToArray()));
        GUILayout.EndArea();
    }
}