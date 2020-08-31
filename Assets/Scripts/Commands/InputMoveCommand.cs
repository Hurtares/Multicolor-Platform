using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputMoveCommand : Command
{
    public override void Execute()
    {
        base.Execute();
        Debug.Log($"Execute Move command");
    }
}
