using UnityEngine;
using System.Collections;

public class Damage : MonoBehaviour {

	public float damageAmount;
	
	private bool canDamage;
	
	private GameObject target;
	private float BetweenHits = 0.5f;
	private float NextHit = -1;

	void OnTriggerEnter (Collider other) {

		print( "target is (Tigger); " + target );
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
		print( "target is (collider); " + target );
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
		print( "target set to " + go );
	}
	
	public void SetCanDamage () {
		canDamage = true;
	}

	public void Update()
	{
		if ( target == null ) return;
		if ( NextHit > Time.time ) return;

		if ( Vector3.Distance( target.transform.position, transform.position ) < 2 )
		{
			Health otherHealth = target.gameObject.GetComponentInChildren<Health>();
			print( otherHealth );

			if ( otherHealth && canDamage )
			{
				otherHealth.TakeDamage( damageAmount );
				NextHit = Time.time + BetweenHits;
			}
		}
	}
}
