using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputMoveCommand : Command
{
    IJumpInput Jump;

    void Awake()
    {
        Jump = GetComponent<IJumpInput>();
    }

    public override void Execute()
    {
        base.Execute();
        Debug.Log($"Execute Move command{Jump.IsPressingJump}");
    }
}
