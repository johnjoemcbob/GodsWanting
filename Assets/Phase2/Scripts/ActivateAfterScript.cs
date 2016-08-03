using UnityEngine;
using System.Collections;

public class ActivateAfterScript : MonoBehaviour
{
	public ActivatableScript OtherScript;
	public ActivatableScript ToActivate;

	protected bool Active = false;

	void Start()
	{
		Active = OtherScript.Activated;
	}

	void Update()
	{
		if ( Active != OtherScript.Activated )
		{
			Active = OtherScript.Activated;
			if ( Active )
			{
				ToActivate.OnDeactivate();
			}
			else
			{
				ToActivate.OnActivate();
			}
		}
	}
}
