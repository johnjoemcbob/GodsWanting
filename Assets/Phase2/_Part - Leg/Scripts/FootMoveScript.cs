using UnityEngine;
using System.Collections;

public class FootMoveScript : MonoBehaviour
{
	public Vector3 RayStart;
	public float RayDistance = 10;
	public float ForceForward = 10;
	public float ForceUp = 10;
	public Vector3 ForceOffset;

	void Update()
	{
		Debug.DrawRay( transform.position + RayStart, -transform.up * RayDistance, Color.red, 10 );
		bool hit = Physics.Raycast( transform.position + RayStart, -transform.up, RayDistance );
		if ( hit )
		{
			Rigidbody body = GetComponentInParent<Rigidbody>();
			body.AddForceAtPosition( body.transform.forward * ForceForward, body.transform.position - ForceOffset );
			body.AddForce( body.transform.up * ForceUp );
		}
	}
}
