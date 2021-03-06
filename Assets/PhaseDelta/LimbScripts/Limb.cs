﻿using UnityEngine;
using System.Collections;

public class Limb : MonoBehaviour {
	
	// public LimbData limbData;
	public string type = "null";
	public string name = "default";
	public string desc = "description";

	public float health;
	public float speed;
	public float damage;
	
	private bool attached;
	public Damage damageScript;
	
	public virtual void SetUp (Rigidbody connectorRB) {
		
	}
	
	void Awake () {
		damageScript = GetComponentInChildren<Damage>();
	}
	
	void Update () {
		if (Vector3.Distance(Vector3.zero, transform.position) > 30)
		{
			transform.position = new Vector3(Random.Range(-3, 3), 5, Random.Range(-3, 3));
			// transform.rotation = Quaternion.identity;
			
			// rb.angularVelocity = Vector3.zero;
			// rb.velocity = Vector3.zero;
		}
	}
	
	public virtual void AttachToDrone () {
		
	}
	
	public virtual void AddToConcoction () {
		
	}
	
	public virtual void ActivateMotion (GameObject go) {
	
	}
	
	public virtual void DeactivateMotion () {
		
	}
	
	public virtual void Attach () {
		attached = true;
		damageScript.SetCanDamage();
	}
	
	public virtual void AttemptClear () {
		if (attached == false)
		{
			// gameObject.SetActive(false);
			Destroy(gameObject);
		}
	}
}
