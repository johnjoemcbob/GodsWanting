using UnityEngine;
using System.Collections;

public class FruitDamage : Fruit {
	
	public override void Awake () {
		base.Awake();
		
		fruitType = "Damage";
	}
	
	public override void AddToCauldron () {
		base.AddToCauldron();
		
		// Debug.Log("ADDED");
		
		float currentPotency = growthPercentage * effectChange;
		currentCauldron.IncreaseDamage(currentPotency);
	}
}