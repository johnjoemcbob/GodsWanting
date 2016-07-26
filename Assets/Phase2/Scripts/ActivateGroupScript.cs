// Matthew Cormack (@johnjoemcbob / www.matthewcormack.co.uk)
// 26/07/16
//
// The Gods Are Wanting
//
// Activate Group Script
// Activate other Activables all at once
//

public class ActivateGroupScript : ActivatableScript
{
	public ActivatableScript[] Activatables;

	public override bool OnActivate()
	{
		if ( !base.OnActivate() ) return false;

		foreach ( ActivatableScript activatable in Activatables )
		{
			activatable.OnActivate();
        }

		return true;
	}
}
