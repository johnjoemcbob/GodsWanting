using UnityEngine;
using System.Collections;

public class Damage : MonoBehaviour {

	public float damageAmount;
	
	private bool canDamage;
	
	private GameObject target;

	void OnTriggerEnter (Collider other) {
		
		if (other.gameObject == target)
		{
			Health otherHealth = other.GetComponent<Health>();
		
			if (otherHealth && canDamage)
			{
				otherHealth.TakeDamage(damageAmount);
			}
		}
	}
	
	void OnCollisionEnter (Collision other) {
		
		if (other.gameObject == target)
		{
			Health otherHealth = other.gameObject.GetComponent<Health>();
		
			if (otherHealth && canDamage)
			{
				otherHealth.TakeDamage(damageAmount);
			}
		}
	}
	
	public void SetTarget (GameObject go) {
		target = go;
	}
	
	public void SetCanDamage () {
		canDamage = true;
	}
}
