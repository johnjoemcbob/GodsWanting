using UnityEngine;
using System.Collections;

public class EnableAtKeyframeScript : MonoBehaviour
{
	public KeyframeAnimationHandlerScript KeyframeAnimation;
	public ActivatableScript Script;
	public float ActivateTime = 0;
	public float DeactivateTime = 1;

	void Update()
	{
		if ( KeyframeAnimation == null ) return;

		if ( KeyframeAnimation.GetSampleTime() < DeactivateTime )
		{
			if ( KeyframeAnimation.GetSampleTime() >= ActivateTime )
			{
				Script.OnActivate();
			}
		}
		else
		{
			Script.OnDeactivate();
		}
	}
}
