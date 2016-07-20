// Matthew Cormack (@johnjoemcbob / www.matthewcormack.co.uk)
// 20/07/16
//
// The Gods Are Wanting
//
// Hover Over Ground Script
// Trace a ray downwards and position the body a set height
// above the hit position
//

using UnityEngine;

public class HoverOverGroundScript : MonoBehaviour
{
	public float HoverHeight = 1;

	void Update()
	{
		// Cast a ray downwards
		RaycastHit hitinfo;
		int layermask = 1 << LayerMask.NameToLayer( "Player" );
		{
			layermask = ~layermask;
		}
		Physics.Raycast( transform.position, -transform.up, out hitinfo, 100, layermask );

		transform.position = hitinfo.point + ( transform.up * HoverHeight );
	}
}
