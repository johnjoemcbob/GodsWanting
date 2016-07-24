// Matthew Cormack (@johnjoemcbob / www.matthewcormack.co.uk)
// 24/07/16
//
// The Gods Are Wanting
//
// Move Towards Target Script
// Move the attached gameobject's transform to a
// target set by other scripts
//

using UnityEngine;

public class MoveTowardsTargetScript : MonoBehaviour
{
	public float MoveSpeed = 1;
	public float TurnSpeed = 1;

	public Vector3 TargetPosition;
	public Vector3 TargetRotation;
	public Vector3 TargetScale;

	// Update is called once per frame
	void Update()
	{
		transform.position += ( TargetPosition - transform.position ) * Time.deltaTime * MoveSpeed;
		transform.rotation = Quaternion.RotateTowards( transform.rotation, Quaternion.Euler( TargetRotation ), Time.deltaTime * TurnSpeed );
	}
}
