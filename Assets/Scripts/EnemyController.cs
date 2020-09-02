using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class EnemyController : MonoBehaviour
{
	[SerializeField] Rigidbody2D Rigidbody2D;
	int direction = 1;

	// Start is called before the first frame update
	void Start()
	{
		StartCoroutine( Patrol() );
	}

	IEnumerator Patrol()
	{
		var speed = 2f;
		StartCoroutine( ChangeDirection(4) );
		while ( true )
		{
			Rigidbody2D.velocity = new Vector2(direction * speed,Rigidbody2D.velocity.y);

			yield return null;

		}
	}

	IEnumerator ChangeDirection(float patrolTime)
	{
		while ( true )
		{
			yield return new WaitForSeconds(patrolTime);
			direction *= -1;
		}
	}
}