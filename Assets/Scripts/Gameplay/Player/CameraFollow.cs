using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Netcode;
using Unity.VisualScripting;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private float cameraSpeed;
    
    private PlayerController _player;
    private Vector3 _distanceFromPlayer;

    private void Awake()
    {
        Observer.StartCamera += StartFollowPlayer;
    }

    private void StartFollowPlayer()
    {
        if (_player == null)
        {
            _player = GamePlayManagers.Instance.GetCurrentPlayer;
            _distanceFromPlayer = transform.position - _player.transform.position;
        }
    }

    private void LateUpdate()
    {
        if (_player != null)
        {
            transform.position = Vector3.Lerp(transform.position, _player.transform.position + _distanceFromPlayer, cameraSpeed); 
        }
    }

    private void OnDestroy()
    {
        Observer.StartCamera -= StartFollowPlayer;
    }
}
