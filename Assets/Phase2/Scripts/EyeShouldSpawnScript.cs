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

public class EyeShouldSpawnScript : ActivatableScript
{
	public List<Collider> Ignore;

	private bool Opening = false;
	private bool Closing = false;
	private Vector3 TargetScale;

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

		// Eyes start closed anyway
		TargetScale = transform.localScale;
		transform.localScale = Vector3.zero;
    }

	void Update()
	{
		if ( Opening )
		{
			transform.localScale = Vector3.Lerp( transform.localScale, TargetScale, Time.deltaTime );
		}
	}

	public override bool OnActivate()
	{
		if ( !base.OnActivate() ) return false;

		Opening = true;
		Closing = false;

		return true;
	}

	public override bool OnDeactivate()
	{
		if ( !base.OnDeactivate() ) return false;

		Opening = false;
		Closing = true;

		return true;
	}
}
