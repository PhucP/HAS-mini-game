using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Netcode;
using UnityEngine;

public class PlayerController : NetworkBehaviour, IBlackHold
{
    public override void OnNetworkSpawn()
    {
        if (IsOwner)
        {
            var trans = transform.position;
            transform.position = new Vector3(trans.x, 0.5f, trans.z);
            
            base.OnNetworkSpawn();
            GamePlayManagers.Instance.ListPlayer.Add(this);
            Observer.StartCamera?.Invoke();
        }
    }

    public void SuckByBlackHold()
    {
        // Do something with blackHold
    }
}
