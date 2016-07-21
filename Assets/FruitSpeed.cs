using UnityEngine;
using System.Collections;

public class FruitSpeed : Fruit {
	
	public override void Awake () {
		base.Awake();
		
		fruitType = "Speed";
	}
	
	public override void AddToCauldron () {
		base.AddToCauldron();
		
		// Debug.Log("ADDED");
		
		float currentPotency = growthPercentage * effectChange;
		currentCauldron.IncreaseSpeed(currentPotency);
	}
}
