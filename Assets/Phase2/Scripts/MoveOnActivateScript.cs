// Matthew Cormack (@johnjoemcbob / www.matthewcormack.co.uk)
// 20/07/16
//
// The Gods Are Wanting
//
// Move On Activate Script
// Move the attached gameobject's transform on activation
// of user input
//

using UnityEngine;

public class MoveOnActivateScript : ActivatableScript
{
	public MoveTowardsTargetScript MoveTarget;

	public Vector3 DirectionChange;
	public Vector3 AngularChange;

	public override bool OnActivate()
	{
		bool success = base.OnActivate();
		if ( !success ) return false;

		// Move
		MoveTarget.TargetPosition += ( DirectionChange.x * transform.forward );
		MoveTarget.TargetPosition += ( DirectionChange.y * transform.up );
		MoveTarget.TargetPosition += ( DirectionChange.z * transform.right );
		MoveTarget.TargetRotation += AngularChange;

		// Move once per activate
		OnDeactivate();
		return true;
	}
}
