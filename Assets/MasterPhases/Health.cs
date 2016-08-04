using UnityEngine;
using System.Collections;

public class Health : MonoBehaviour {
	
	public float startingHealth;
	public float currentHealth;
	
	public bool damageable = true;
	
	public delegate void Dead();
	public Dead dead;
	
	public delegate void DamageCallback(float newHealth);
	public DamageCallback damageCallback;
	
	public void SetUp (float h) {
		startingHealth = h;
		currentHealth = h;
		
		// Debug.Log(currentHealth);
	}
	
	public void UpdateDamageable (bool d) {
		damageable = d;
	}
		
	public void TakeDamage (float d) {
		if (damageable)
		{
			currentHealth -= d;
			
			//visual damage
			if (damageCallback != null)
			{
				damageCallback(currentHealth);
			}
			
			if (currentHealth <= 0)
			{
				// Dead();
				// SendMessage(DeadM8, false);
				// Debug.Log(currentHealth);
				dead();
			}
		}
	}
	
	public void GainHealth (float h) {
		currentHealth = Mathf.Clamp(currentHealth + h, 0, startingHealth);
		
		if (damageCallback != null)
		{
			damageCallback(currentHealth);
		}
	}
	
	// public void VisualDamage () {
	
	// }
	
	// public void Dead () {
		
	// }
}
