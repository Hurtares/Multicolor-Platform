using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;
using UnityEngine.InputSystem;

public class SpawnController : MonoBehaviour
{
    [SerializeField] CinemachineTargetGroup TargetGroup;

    void OnPlayerJoined(PlayerInput input)
    {
        Debug.Log("joined");
        TargetGroup.AddMember(input.gameObject.transform, 1, 9 );
    }
}
