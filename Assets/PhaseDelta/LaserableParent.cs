using UnityEngine;
using System.Collections;

public class LaserableParent : Laserable {
	
	private HingeJoint hinge;
	private Limb limbScript;
	
	public override void Awake () {
		base.Awake();
		
		hinge = GetComponentInChildren<HingeJoint>();
		limbScript = GetComponentInChildren<Limb>();
	}
	
	public override void Lase (Laser l) {
		base.Lase(l);
		
		if (hinge)
		{
			// hinge.useMotor = false;
		}
		
		// rb.mass = 100;
		
		limbScript.DeactivateMotion();
	}
}
