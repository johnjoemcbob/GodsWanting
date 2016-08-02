// Matthew Cormack (@johnjoemcbob / www.matthewcormack.co.uk)
// 24/07/16
//
// The Gods Are Wanting
//
// Timed Deactivation Script
// Activate another activatable script then
// deactivate after a variable time frame
//

using UnityEngine;

public class TimedDeactivationScript : ActivatableScript
{
	public ActivatableScript Script;
	public float RunTime = 1;

	private float StartTime = -1;

	void Start()
	{
		if ( Activated )
		{
			Activated = false;
			OnActivate();
		}
	}

	void Update()
	{
		if ( StartTime == -1 ) return;

		if ( ( StartTime + RunTime ) <= Time.time )
		{
			OnDeactivate();
			Script.OnDeactivate();
			StartTime = -1;
        }
	}

	public override bool OnActivate()
	{
		bool success = base.OnActivate();
		if ( !success ) return false;

		// Start other activatable and count down
		Script.OnActivate();
		StartTime = Time.time;

		return true;
	}
}
