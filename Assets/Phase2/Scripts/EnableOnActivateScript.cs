using UnityEngine;
using System.Collections;

public class EnableOnActivateScript : ActivatableScript
{
	public GameObject[] ToEnable;
	public bool Backwards = false;

	public override bool OnActivate()
	{
		if ( !base.OnActivate() ) return false;

		foreach ( GameObject item in ToEnable )
		{
			item.SetActive( !Backwards );
		}

		return true;
	}

	public override bool OnDeactivate()
	{
		if ( !base.OnDeactivate() ) return false;

		foreach ( GameObject item in ToEnable )
		{
			item.SetActive( Backwards );
		}

		return true;
	}
}
