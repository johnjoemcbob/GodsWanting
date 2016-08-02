// Matthew Cormack
// 02/08/16
//
// The Gods Are Wanting
//
// Crouch Jump Script
// Control the crouching/standing/jumping functionality
// of the gods, depending on player trigger hold down
//

using UnityEngine;

public class CrouchJumpScript : MonoBehaviour
{
	// References to the two legs of this god
	public GameObject[] Legs;
	public string CrouchButton_Player1 = "";
	public string CrouchButton_Player2 = "";
	public float Gravity = 1;
	public float CrouchStart = 0.3f;
	public float JumpStart = 0.8f;
	public float JumpTimeMax = 0.2f;
	public float JumpSpeed = 2;
	public float JumpHeight = 0.5f;

	private HoverOverGroundScript Hover;
	private float DefaultHover = -1;
	private float CurrentHeight = 1;
	private bool Crouched = false;
	private bool Jumped = false;
	private float CrouchTime = -1;

	void Start()
	{
		Hover = GetComponent<HoverOverGroundScript>();
        DefaultHover = Hover.HoverHeight;
	}

	void Update()
	{
		float p1 = 1 - Input.GetAxis( CrouchButton_Player1 );
		float p2 = 1 - Input.GetAxis( CrouchButton_Player2 );
		float mean = ( p1 + p2 ) / 2;
		CurrentHeight = mean;

		// Update Visuals
		if ( ( Hover.HoverHeight <= DefaultHover ) && ( !Jumped ) )
		{
			float div = 4;
			Hover.HoverHeight = DefaultHover * ( ( 1 - ( 1 / div ) ) + ( mean / div ) );
			Update_Leg( Legs[0], p1 );
			Update_Leg( Legs[1], p2 );

			Update_CheckJump();
		}
		// Jumping
		else
		{
			// Rise
			if ( Jumped )
			{
				Hover.HoverHeight += Time.deltaTime * JumpSpeed;
				if ( Hover.HoverHeight >= ( DefaultHover + JumpHeight ) )
				{
					Jumped = false;
				}
            }
			// Fall
			else
			{
				Hover.HoverHeight -= Time.deltaTime * Gravity;
			}
        }
	}

	private void Update_Leg( GameObject leg, float held )
	{
		float div = 3;
        held = ( held / div );
		held = ( 1 - ( 1 / div ) ) + held;
		leg.transform.GetChild( 0 ).localScale = new Vector3( 1, held, 1 );
	}

	private void Update_CheckJump()
	{
		if ( CurrentHeight <= CrouchStart )
		{
			Crouched = true;
			CrouchTime = Time.time;
		}
		else if ( Crouched && ( CurrentHeight >= JumpStart ) )
		{
			// Check for jumping (i.e. quick release)
			float timedif = Time.time - CrouchTime;
            if ( timedif <= JumpTimeMax )
			{
				Jumped = true;
			}
			Crouched = false;
        }
	}
}
