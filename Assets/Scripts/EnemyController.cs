using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
	[SerializeField] Rigidbody2D Rigidbody2D;

	// Start is called before the first frame update
	void Start()
	{
		StartCoroutine( Patrol() );
	}

	IEnumerator Patrol()
	{
		while ( true )
		{
			Rigidbody2D.velocity = Vector2.right * 2;

			yield return new WaitForSeconds( 3 );

			Rigidbody2D.velocity = Vector2.left * 2;
			
			yield return new WaitForSeconds( 3 );
		}
	}
}