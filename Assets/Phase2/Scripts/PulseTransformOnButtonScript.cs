using UnityEngine;
using System.Collections;

public class PulseTransformOnButtonScript : MonoBehaviour
{
	// Public Inspector
	public string Button = "Fire1";
	public int CyclesPerPress = 1;
	public PulseTransformScript[] PulseTransforms;

	void Update()
	{
		if ( PulseTransforms == null ) return;
		if ( PulseTransforms.Length == 0 ) return;

		if ( Input.GetButtonDown( Button ) )
		{
			foreach ( PulseTransformScript pulser in PulseTransforms )
			{
				pulser.Enable( 2 );
			}
		}
	}
}
