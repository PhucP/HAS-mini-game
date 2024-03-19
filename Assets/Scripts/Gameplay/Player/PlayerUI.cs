using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerUI : MonoBehaviour
{
    [SerializeField] private GameObject player;

    private Vector3 _distanceFromPlayer;
    private Camera MainCamera => Camera.main;

    private void Awake()
    {
        _distanceFromPlayer = transform.position - MainCamera.WorldToScreenPoint(player.transform.position);
    }

    private void LateUpdate()
    {
        transform.position = MainCamera.WorldToScreenPoint(player.transform.position) + _distanceFromPlayer;
    }
}
