// Matthew Cormack (@johnjoemcbob / www.matthewcormack.co.uk)
// 02/08/16
//
// The Gods Are Wanting
//
// Move Forward On Activate Script
// Move the attached gameobject's transform forward on
// activation of user input
//

using UnityEngine;

public class MoveForwardOnActivateScript : MoveOnActivateScript
{
	public Vector3 MoveSpeed;
	public GameObject DirectionObject;
	public GameObject RotationBody;

	public override bool OnActivate()
	{
		DirectionChange = new Vector3(
			( DirectionObject.transform.forward.z * MoveSpeed.x ),
			( DirectionObject.transform.forward.y * MoveSpeed.y ),
			( DirectionObject.transform.forward.x * MoveSpeed.z )
		);

		RotationBody.transform.rotation = Quaternion.LookRotation( DirectionObject.transform.forward );

		return base.OnActivate();
	}
}
