using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerController : MonoBehaviour
{
    [SerializeField] FallingBridgeController target;
    void OnTriggerEnter2D( Collider2D other )
    {
        if ( other.tag == "Player" )
        {
            target.LowerBridge();
        }
    }
}
