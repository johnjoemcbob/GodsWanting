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
	public Vector3 DirectionChange;
	public Vector3 AngularChange;

	protected Vector3 TargetPosition;
	protected Vector3 TargetRotation;

	void Update()
	{
		transform.position += ( TargetPosition - transform.position ) * Time.deltaTime;
		transform.rotation = Quaternion.Euler( transform.eulerAngles + ( TargetRotation - transform.eulerAngles ) * Time.deltaTime );
	}

	public override bool OnActivate()
	{
		bool success = base.OnActivate();
		if ( !success ) return false;

		// Move
		TargetPosition += ( DirectionChange.x * transform.forward );
		TargetPosition += ( DirectionChange.y * transform.up );
		TargetPosition += ( DirectionChange.z * transform.right );
		TargetRotation += AngularChange;

		// Move once per activate
		OnDeactivate();
		return true;
	}
}
