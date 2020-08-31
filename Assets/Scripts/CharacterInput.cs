using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CharacterInput : MonoBehaviour, IMoveInput, IJumpInput
{
    //commands
    public Command jumpInput;
    
    PlayerInputActions inputActions;
    
    //inputs
    public Vector2 MoveDirection { get; private set; }
    public bool IsPressingJump { get; private set; }

    void Awake()
    {
        inputActions = new PlayerInputActions();
    }

    void OnEnable()
    {
        inputActions.Enable();
        inputActions.Player.Jump.performed += OnJumpButton;
    }

    void OnDisable()
    {
        inputActions.Disable();
        inputActions.Player.Jump.performed -= OnJumpButton;
    }

    void OnJumpButton( InputAction.CallbackContext context )
    {
        Debug.Log( $"Jump button pressed,{context.ReadValue<float>()}" );
        IsPressingJump = context.ReadValue<float>() >= .2f;

        if ( jumpInput != null && IsPressingJump)
        {
            jumpInput.Execute();
        }
    }
}