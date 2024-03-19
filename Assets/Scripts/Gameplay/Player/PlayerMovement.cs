using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Netcode;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : NetworkBehaviour
{
    [SerializeField] private float moveSpeed;

    private Vector2 _moveDirection;

    public override void OnNetworkSpawn()
    {
        base.OnNetworkSpawn();
        if (!IsOwner) enabled = false;
    }

    //Input system
    private void Update()
    {
        HandleMovement();
    }

    private void HandleMovement()
    {
        var movement = new Vector3(_moveDirection.x, 0f, _moveDirection.y);
        movement.Normalize();
        //transform.forward = movement;
        transform.Translate(movement * (moveSpeed * Time.deltaTime));
    }

    public void InputPlayer(InputAction.CallbackContext context)
    {
        _moveDirection = context.ReadValue<Vector2>();
    }
}