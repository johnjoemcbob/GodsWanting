// Matthew Cormack (@johnjoemcbob / www.matthewcormack.co.uk)
// 02/08/16
//
// The Gods Are Wanting
//
// Eye Should Spawn Script
// Toggle possible eyes based on chance and
// if there is no collision
//

using UnityEngine;
using System.Collections.Generic;

public class EyeShouldSpawnScript : MonoBehaviour
{
	public List<Collider> Ignore;

	void Start()
	{
		bool collision = false;
		foreach ( Collider col in Physics.OverlapSphere( transform.position, transform.localScale.x ) )
		{
			if  ( !Ignore.Contains( col ) )
			{
				collision = true;
				break;
			}
		}
		if ( collision || ( Random.Range( 0, 10 ) <= 5 ) )
		{
			gameObject.SetActive( false );
		}
	}
}
