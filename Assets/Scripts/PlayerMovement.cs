using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    PlayerInputActions inputActions;
    [SerializeField] Rigidbody2D Rigidbody2D;

    Vector2 direction;
    bool IsMoving;
    const float Speed = 10;
    const float JumpStrength = 500;

    void Awake()
    {
        inputActions = new PlayerInputActions();
    }

    void OnEnable()
    {
        inputActions.Enable();
        inputActions.Player.Movement.performed += OnMovementInput;
        inputActions.Player.Jump.performed += OnJumpInput;
    }


    void OnDisable()
    {
        inputActions.Player.Movement.performed -= OnMovementInput;
        inputActions.Player.Jump.performed -= OnJumpInput;
        inputActions.Disable();
    }
    
    void OnJumpInput( InputAction.CallbackContext obj )
    {
        Rigidbody2D.AddForce(Vector2.up * JumpStrength);
    }

    void OnMovementInput( InputAction.CallbackContext obj )
    {
        direction = obj.ReadValue<Vector2>();
        Rigidbody2D.velocity = new Vector2(direction.x * Speed  , Rigidbody2D.velocity.y);
    }
    

}
