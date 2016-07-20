// Matthew Cormack (@johnjoemcbob / www.matthewcormack.co.uk)
// 20/07/16
//
// The Gods Are Wanting
//
// Rotate To Face Object Script
// Rotate the the attached gameobject to
// face the defined target
//

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
