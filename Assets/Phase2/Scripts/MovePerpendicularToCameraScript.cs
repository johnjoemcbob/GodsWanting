// Matthew Cormack
// 01/07/16
//
// The Gods Are Wanting
//
// Move Perpendicular To Camera Script
// Transform movement vectors to always be in cardinal relation
// to a camera gameobject
//

using UnityEngine;

public class MovePerpendicularToCameraScript : MonoBehaviour
{
	public GameObject CameraParent;
	public float MoveDistance = 10;

	protected Vector3 MoveTarget;

	void Start()
	{
		if ( CameraParent == null )
		{
			CameraParent = Camera.main.gameObject;
		}
	}

	void Update()
	{
		if ( Input.GetKey( KeyCode.W ) )
		{
			Move( Vector3.forward * Time.deltaTime * MoveDistance );
		}
		if ( Input.GetKey( KeyCode.S ) )
		{
			Move( -Vector3.forward * Time.deltaTime * MoveDistance );
		}
		if ( Input.GetKey( KeyCode.A ) )
		{
			Move( -Vector3.right * Time.deltaTime * MoveDistance );
		}
		if ( Input.GetKey( KeyCode.D ) )
		{
			Move( Vector3.right * Time.deltaTime * MoveDistance );
		}

		transform.position += MoveTarget;
        MoveTarget = Vector3.zero;
    }

	protected Vector3 Move( Vector3 direction )
	{
		Vector3 camera_noup_forward = new Vector3( CameraParent.transform.forward.x, 0, CameraParent.transform.forward.z );
		Vector3 camera_noup_right = new Vector3( CameraParent.transform.right.x, 0, CameraParent.transform.right.z );

		Vector3 forward = direction.x * camera_noup_right;
		Vector3 up = direction.y * CameraParent.transform.up;
		Vector3 right = direction.z * camera_noup_forward;
		MoveTarget = forward + up + right;

		return MoveTarget;
    }
}
