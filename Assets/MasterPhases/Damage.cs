﻿using UnityEngine;
using System.Collections;

public class Damage : MonoBehaviour {

	public float damageAmount;

	void OnTriggerEnter (Collider other) {
		
		Health otherHealth = other.GetComponent<Health>();
	
		if (otherHealth)
		{
			otherHealth.TakeDamage(damageAmount);
		}
	}
}
