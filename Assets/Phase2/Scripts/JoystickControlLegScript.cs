// Matthew Cormack
// 01/08/16
//
// The Gods Are Wanting
//
// Joystick Control Leg Script
// Control the attached leg with a specific joystick
// to drag the body towards the direction of movement
// in another script
//

using UnityEngine;

public class JoystickControlLegScript : MovePerpendicularToCameraScript
{
	public string Joystick_Horizontal = "";
	public string Joystick_Vertical = "";

	void Update()
	{
		if ( CameraParent == null )
		{
			CameraParent = Camera.main.gameObject;
		}

		if ( Joystick_Horizontal == "" ) return;
		if ( Joystick_Vertical == "" ) return;

		float hor = Input.GetAxis( Joystick_Horizontal );
		float ver = Input.GetAxis( Joystick_Vertical );
		if ( ( hor != 0 ) || ( ver != 0 ) )
		{
			Move( new Vector3( hor, 0, ver ) );

			transform.rotation = Quaternion.LookRotation( MoveTarget, Vector3.up );
		}
	}
}
