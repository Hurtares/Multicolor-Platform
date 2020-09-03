using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.InputSystem;
using Random = UnityEngine.Random;

public class PlayerMovement : MonoBehaviour
{
    PlayerInputActions inputActions;
    [SerializeField] Rigidbody2D Rigidbody2D;

    Vector2 direction;
    bool IsMoving;
    const float Speed = 10;
    const float JumpStrength = 500;

    string[] layers = new string[]
    {
        "Red", "Green", "Blue"
    };

    void Awake()
    {
        inputActions = new PlayerInputActions();
    }

    void OnEnable()
    {
        inputActions.Enable();
        inputActions.Player.ChangeRed.performed += _ => OnColorInput("Red");
        inputActions.Player.ChangeGreen.performed += _ => OnColorInput("Green");
        inputActions.Player.ChangeBlue.performed += _ => OnColorInput("Blue");
    }


    void OnDisable()
    {
        inputActions.Player.ChangeRed.performed -= _ => OnColorInput("Red");
        inputActions.Player.ChangeGreen.performed -= _ => OnColorInput("Green");
        inputActions.Player.ChangeBlue.performed -= _ => OnColorInput("Blue");
        inputActions.Disable();
    }
    
    void OnColorInput( string color )
    {
        gameObject.layer = LayerMask.NameToLayer(color);

        if ( color == "Blue" )
        {
            GetComponent<SpriteRenderer>().color = Color.blue;
            return;
        }else if ( color == "Red"  )
        {
            GetComponent<SpriteRenderer>().color = Color.red;
            return;
        }
        
        GetComponent<SpriteRenderer>().color = Color.green;
        
    }
    
    void OnJump( )
    {
        Rigidbody2D.AddForce(Vector2.up * JumpStrength);
    }

    void OnMovement(InputValue value )
    {
        //this.direction = direction;
        Debug.Log("OnMovement" );
        direction = value.Get<Vector2>();
        IsMoving = Math.Abs( direction.x ) > .1f;
        StartCoroutine( SetVelocity() );
    }

    IEnumerator SetVelocity()
    {
        while ( true )
        {
            Rigidbody2D.velocity = new Vector2(direction.x * Speed  , Rigidbody2D.velocity.y);
            yield return new WaitForEndOfFrame();

            if ( !IsMoving )
            {
                yield break;
            }
        }
    }

    void OnCollisionEnter2D( Collision2D other )
    {
        if ( other.gameObject.CompareTag( "Enemy" ) )
        {
            transform.position = new Vector3(-10,0,0);
        }
    }
}
