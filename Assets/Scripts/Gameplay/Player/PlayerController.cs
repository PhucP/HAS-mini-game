using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Netcode;
using UnityEngine;

public class PlayerController : NetworkBehaviour
{
    public bool FakeOner;
    private void Start()
    {
        FakeOner = true;
        GamePlayManagers.Instance.ListPlayer.Add(this);
        Observer.StartCamera?.Invoke();
    }
}
