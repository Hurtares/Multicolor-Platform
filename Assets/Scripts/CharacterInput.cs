using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CharacterInput : MonoBehaviour, IMoveInput, IJumpInput
{
    //commands
    public Command MoveInput;
    
    //inputs
    public Vector2 MoveDirection { get; private set; }
    public bool IsPressingJump { get; private set; }

    //inputSystem
    PlayerInputActions inputActions;

    void Awake()
    {
        inputActions = new PlayerInputActions();
    }

    void OnEnable()
    {
        inputActions.Enable();
        inputActions.Player.Jump.performed += OnJumpButton;
        inputActions.Player.Movement.performed += OnMoveButton;
    }

    void OnDisable()
    {
        inputActions.Disable();
        inputActions.Player.Jump.performed -= OnJumpButton;
        inputActions.Player.Movement.performed -= OnMoveButton;
    }

    void OnMoveButton( InputAction.CallbackContext context )
    {
        MoveDirection = context.ReadValue<Vector2>();
        
        if ( MoveInput != null )
        {
            MoveInput.Execute();
        }
    }

    void OnJumpButton( InputAction.CallbackContext context )
    {
        IsPressingJump = context.ReadValue<float>() >= .2f;

        if ( MoveInput != null )
        {
            MoveInput.Execute();
        }
    }
}