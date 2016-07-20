using UnityEngine;
using System.Collections;

public class RotateToFaceObjectScript : MonoBehaviour
{
	public GameObject TargetObject;

	void Update()
	{
		if ( TargetObject != null )
		{
			Vector3 forward = ( TargetObject.transform.position - transform.position ).normalized;
			transform.rotation = Quaternion.LookRotation( forward );
		}
	}
}
