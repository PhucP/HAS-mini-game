using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Netcode;
using UnityEngine;

public class TempNetworkButton : MonoBehaviour
{
    private void OnGUI()
    {
        var network = NetworkManager.Singleton;
        
        GUILayout.BeginArea(new Rect(10, 10, 300, 300));
        if (!network.IsClient && !network.IsServer)
        {
            if (GUILayout.Button("Host")) network.StartHost();
            if (GUILayout.Button("Server")) network.StartServer();
            if (GUILayout.Button("Client")) network.StartClient();
        }
        
        GUILayout.EndArea();
    }
}
