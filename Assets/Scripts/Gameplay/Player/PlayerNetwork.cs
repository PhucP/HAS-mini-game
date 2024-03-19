using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Netcode;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerNetwork : NetworkBehaviour
{
    private readonly NetworkVariable<PlayerNetworkData> playerData = new NetworkVariable<PlayerNetworkData>(writePerm: NetworkVariableWritePermission.Owner);

    [SerializeField] private float cheapInterpolationTime = 0.1f;
    
    private Vector3 _vel;

    private void Update()
    {
        if (IsOwner)
        {
            // Send data to server
            playerData.Value = new PlayerNetworkData()
            {
                Pos = transform.position
            };
        }
        else
        {
            // Read data from server and use it for this player
            transform.position = Vector3.SmoothDamp(transform.position, playerData.Value.Pos, ref _vel, cheapInterpolationTime);
        }
    }
}

struct PlayerNetworkData : INetworkSerializable
{
    private float x;
    private float z;

    internal Vector3 Pos
    {
        get => new Vector3(x, 0.5f, z);
        set
        {
            x = value.x;
            z = value.z;
        }
    }


    public void NetworkSerialize<T>(BufferSerializer<T> serializer) where T : IReaderWriter
    {
        serializer.SerializeValue(ref x);
        serializer.SerializeValue(ref z);
    }
}
