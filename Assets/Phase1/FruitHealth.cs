using UnityEngine;
using System.Collections;

public class FruitHealth : Fruit {
	
	public override void Awake () {
		base.Awake();
		
		fruitType = "Health";
	}
	
	public override void AddToCauldron () {
		base.AddToCauldron();
		
		// Debug.Log("ADDED");
		
		float currentPotency = growthPercentage * effectChange;
		currentCauldron.IncreaseHealth(currentPotency);
	}
}