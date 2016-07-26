// Matthew Cormack (@johnjoemcbob / www.matthewcormack.co.uk)
// 26/07/16
//
// The Gods Are Wanting
//
// Rotate To Face Cursor Script
// Rotate the attached gameobject to
// face the 2D cursor position
//

using UnityEngine;
using System.Collections;

public class RotateToFaceCursorScript : MonoBehaviour
{
	public float DistanceForward = 5;

	void Start()
	{
		Application.runInBackground = true;
	}

	void Update()
	{
		Vector3 mouse = Camera.main.ScreenToWorldPoint( new Vector3( Input.mousePosition.x, Input.mousePosition.y, DistanceForward ) );

		Vector3 forward = ( mouse - transform.position ).normalized;
		transform.rotation = Quaternion.LookRotation( forward );
	}
}
