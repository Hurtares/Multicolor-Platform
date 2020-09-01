using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputMoveCommand : Command
{
    IJumpInput Jump;
    IMoveInput Move;

    void Awake()
    {
        Jump = GetComponent<IJumpInput>();
        Move = GetComponent<IMoveInput>();
    }

    public override void Execute()
    {
        base.Execute();
        Debug.Log($"Execute Move command {Move.MoveDirection}, and is jumping:{Jump.IsPressingJump}");
        
        GetComponent<Rigidbody2D>().AddForce( Move.MoveDirection * 10 );
    }
}
