// Matthew Cormack
// 02/08/16
//
// The Gods Are Wanting
//
// Record GIF Script
// Uses the Moments Recorder
// https://github.com/Chman/Moments
//

using UnityEngine;

public class RecordGIFScript : MonoBehaviour
{
	void Start()
	{
		GetComponent<Moments.Recorder>().Record();
    }

	void Update()
	{
		if ( Input.GetKeyDown( KeyCode.Backspace ) )
		{
			GetComponent<Moments.Recorder>().Save( "testgif" );
		}
	}
}
