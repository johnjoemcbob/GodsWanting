using UnityEngine;
using System.Collections;

public class Limb : MonoBehaviour {
	
	// public LimbData limbData;
	public string type = "null";
	public string name = "default";
	public string desc = "description";

	public float health;
	public float speed;
	public float damage;
	
	public virtual void SetUp (Rigidbody connectorRB) {
		
	}
	
	public virtual void AttachToDrone () {
		
	}
	
	public virtual void AddToConcoction () {
		
	}
	
	public virtual void ActivateMotion () {
	
	}
	
	public virtual void DeactivateMotion () {
		
	}
}
