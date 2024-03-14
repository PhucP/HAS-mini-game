using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.Collections;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class GamePlayManagers : MonoBehaviour
{
    public static GamePlayManagers Instance;

    [SerializeField] private List<PlayerController> listPlayer = new List<PlayerController>();
    
    public List<PlayerController> ListPlayer => listPlayer;
    public PlayerController GetCurrentPlayer => listPlayer.FirstOrDefault(player => player.FakeOner);

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(this);
        }

        Instance = this;
    }
}
