using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Body : MonoBehaviour {
	
	public List<Limb> attachedLimbs;

	public Body()
	{
		attachedLimbs = new List<Limb>();
	}
	
	void Update () {
		if (Input.GetKeyDown("a"))
		{
			ActivateLimbs();
		}
	}
	
	public void ActivateLimbs () {
		ActivateLegs();
		
		for (int i = 0; i < attachedLimbs.Count; i++)
		{
			attachedLimbs[i].ActivateMotion();
		}
	}
	
	public void ActivateLegs () {
		
	}
	
	void OnTriggerEnter (Collider other) {
		Connector c = other.gameObject.GetComponent<Connector>();
	
		if (c != null)
		{
			if (gameObject.GetComponent<FixedJoint>() == null)
			{
				gameObject.AddComponent<FixedJoint>();  
				gameObject.GetComponent<FixedJoint>().connectedBody = other.gameObject.GetComponent<Rigidbody>();
				
				// other.gameObject.GetComponent<Rigidbody>().mass = 1;
				
				attachedLimbs.Add(other.gameObject.GetComponentInChildren<Limb>());
			}
		}
	}
}
