using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Body : MonoBehaviour {
	
	public List<Limb> attachedLimbs;
	public string godName;
	
	public GameObject otherGod;
	
	private Health health;

	public Body()
	{
		attachedLimbs = new List<Limb>();
	}
	
	void Awake () {
		health = GetComponent<Health>();
		
		health.dead = Dead2;
		// health.damageCallback = Damage;
		
		
	}
	
	// public void SetUp (GameObject go) {
		// otherGod = go;
	// }
	
	void Update () {
		// if (Input.GetKeyDown("a"))
		// {
			// ActivateLimbs();
		// }
	}
	
	public void ActivateLimbs () {
		ActivateLegs();
		
		for (int i = 0; i < attachedLimbs.Count; i++)
		{
			attachedLimbs[i].ActivateMotion(otherGod);
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
				
				gameObject.GetComponent<Laserable>().CannotLaser();
				
				// other.gameObject.GetComponent<Rigidbody>().mass = 1;
				
				attachedLimbs.Add(other.gameObject.GetComponentInChildren<Limb>());
			}
		}
	}
	
	public void Dead2 () {
		//kill it
		
		GameObject.Find("Managers").GetComponent<GameManager>().TheEnd(godName);
	}
}
