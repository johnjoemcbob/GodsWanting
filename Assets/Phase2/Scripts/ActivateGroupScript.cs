// Matthew Cormack (@johnjoemcbob / www.matthewcormack.co.uk)
// 26/07/16
//
// The Gods Are Wanting
//
// Activate Group Script
// Activate other Activables all at once
//

using System.Collections.Generic;

public class ActivateGroupScript : ActivatableScript
{
	public List<ActivatableScript> Activatables;

	public override bool OnActivate()
	{
		if ( !base.OnActivate() ) return false;

		foreach ( ActivatableScript activatable in Activatables )
		{
			activatable.OnActivate();
        }

		return true;
	}

	public override bool OnDeactivate()
	{
		if ( !base.OnDeactivate() ) return false;

		foreach ( ActivatableScript activatable in Activatables )
		{
			activatable.OnDeactivate();
		}

		return true;
	}
}
