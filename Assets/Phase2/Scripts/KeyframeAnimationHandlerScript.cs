// Matthew Cormack (@johnjoemcbob / www.matthewcormack.co.uk)
// 20/07/16
//
// The Gods Are Wanting
//
// Keyframe Animation GameObject Handler Script
// Handles communication between Unity scene gameobjects
// and the KeyframeAnimation script
//

using UnityEngine;

public class KeyframeAnimationHandlerScript : ActivatableScript
{
	#region Variable Declaration
	[Header( "Keyframe Animation Handler" )]
	public bool UsePosition = true;
	public bool UseRotation = false;
	public bool UseScale = false;

	public float AnimationSpeed = 1;
	public float AnimationTime = 1;

	public KeyframeStruct[] Keyframes;

	private KeyframeAnimationScript Animation = new KeyframeAnimationScript();
	private float Time_Sample = 0;
	#endregion

	// Use this for initialization
	void Start()
	{
		if ( Keyframes.Length > 0 )
		{
			Animation.ResizeKeyframeArray( Keyframes.Length );
			foreach ( KeyframeStruct keyframe in Keyframes )
			{
				Animation.AddKeyframe( keyframe );
			}
			Animation.SortKeyframeArray();
		}
	}

	// Update is called once per frame
	void Update()
	{
		if ( !Activated ) return;

		// Advance timestamp
		Time_Sample += Time.deltaTime * AnimationSpeed;
		{
			if ( Time_Sample > AnimationTime )
			{
				OnDeactivate();
			}
		}
		KeyframeStruct keyframe = Animation.GetKeyframeAtTime( Time_Sample );

		// Use keyframe data
		if ( UsePosition )
		{
			transform.localPosition = keyframe.Position;
		}
		if ( UseRotation )
		{
			transform.localEulerAngles = keyframe.Rotation;
		}
		if ( UseScale )
		{
			transform.localScale = keyframe.Scale;
		}
	}

	public override bool OnActivate()
	{
		bool success = base.OnActivate();
		if ( !success )
		{
			OnDeactivate();
			base.OnActivate();
		}

		Time_Sample = 0;
		return true;
	}

	public override bool OnDeactivate()
	{
		bool success = base.OnDeactivate();
		if ( !success ) return false;

		Time_Sample = 0;
		return true;
	}
}
