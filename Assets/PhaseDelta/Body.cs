using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Body : MonoBehaviour {
	
	public List<Limb> attachedLimbs;
	public string godName;
	
	public GameObject otherGod;
	
	private Health health;
	
	private Vector3 spawnPos;
	private Rigidbody rb;

	public Body()
	{
		attachedLimbs = new List<Limb>();
	}
	
	void Awake () {
		health = GetComponent<Health>();
		
		health.dead = Dead2;
		health.damageCallback = DamageCallback;
		// health.damageCallback = Damage;
		
		rb = GetComponent<Rigidbody>();
	}
	
	public void SetUp (Vector3 v) {
		spawnPos = v;
	}
	
	void Update () {
		// if (Input.GetKeyDown("a"))
		// {
			// ActivateLimbs();
		// }
		
		if (Vector3.Distance(Vector3.zero, transform.position) > 30)
		{
			transform.parent.parent.position = spawnPos;
			transform.rotation = Quaternion.identity;
			
			rb.angularVelocity = Vector3.zero;
			rb.velocity = Vector3.zero;
			
			health.TakeDamage(10);
		}
	}
	
	public void ActivateLimbs () {
		ActivateLegs();
		
		for (int i = 0; i < attachedLimbs.Count; i++)
		{
			if ( attachedLimbs[i] == null ) continue;

			attachedLimbs[i].ActivateMotion(otherGod);
		}
	}
	
	public void ActivateLegs () {
		
	}
	
	void OnTriggerEnter (Collider other) {
		Connector c = other.gameObject.GetComponent<Connector>();
	
		if (c != null)
		{
			//if (gameObject.GetComponent<FixedJoint>() == null)
			{
				FixedJoint joint = gameObject.AddComponent<FixedJoint>();
				joint.connectedBody = other.gameObject.GetComponent<Rigidbody>();
				
				other.gameObject.GetComponent<Laserable>().CannotLaser();
				other.gameObject.GetComponentInChildren<Limb>().Attach();
				other.gameObject.GetComponentInChildren<Damage>().SetUpSelf(gameObject);
				
				// other.gameObject.GetComponent<Rigidbody>().mass = 1;
				
				attachedLimbs.Add(other.gameObject.GetComponentInChildren<Limb>());
			}
		}
		
		// Debug.Log(other.gameObject);
	}
	
	void OnCollisionEnter (Collision other) {
		
		Damage d = other.gameObject.GetComponent<Damage>();
		
		if (d != null)
		{
			// health.TakeDamage(10);
		}
		
		
		// Debug.Log("Body collided with: " + other.gameObject);
	}
	
	public void Dead2 () {
		//kill it
		
		GameObject.Find("Managers").GetComponent<GameManager>().TheEnd(godName);
	}
	
	public void DamageCallback (float d) {
		Debug.Log(health.currentHealth);
	}
}
