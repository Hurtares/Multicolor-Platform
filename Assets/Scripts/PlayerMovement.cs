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
    string currentColor= "Blue";
    const float Speed = 10;
    const float JumpStrength = 500;

    List<string> colors = new List<string>()
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
    }

    void OnDisable()
    {
        inputActions.Disable();
    }

    void OnPreviousColor()
    {
        int index = colors.IndexOf( currentColor );
        SetColor(colors[ (index + 2) % 3]);
        Debug.Log("hhsdh");
    }
    
    void OnNextColor()
    {
        int index = colors.IndexOf( currentColor );
        SetColor(colors[(index + 1) % 3]);
        Debug.Log("hhsdh2");
    }

    void OnJump( )
    {
        Rigidbody2D.AddForce(Vector2.up * JumpStrength);
    }

    void OnMovement(InputValue value )
    {
        direction = value.Get<Vector2>();
        IsMoving = Math.Abs( direction.x ) > .1f;
        StartCoroutine( SetVelocity() );
    }
    
    void SetColor( string color )
    {
        gameObject.layer = LayerMask.NameToLayer(color);
        
        if ( color == "Blue" )
        {
            GetComponent<SpriteRenderer>().color = Color.blue;
            currentColor = color;
            return;
        }else if ( color == "Red"  )
        {
            GetComponent<SpriteRenderer>().color = Color.red;
            currentColor = color;
            return;
        }
        GetComponent<SpriteRenderer>().color = Color.green;
        currentColor = color;
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
