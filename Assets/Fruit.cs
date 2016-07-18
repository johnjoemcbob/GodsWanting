using UnityEngine;
using System.Collections;

public class Fruit : PickUpAble {
	
	public GameObject tree;
	
	public Vector3 minSize;
	public Vector3 maxSize;
	
	public float timeUntilFall;
	public float fallTime;
	public float plantTime;
	
	private float currentGrowth;
	private bool germinated;
	private bool planting;
	
	public enum FruitStates {
		Growing,
		OnGround,
		Held,
		InCauldron
	} public FruitStates fruitState;
	
	public void SetUp (bool fromTree) {
		if (fromTree)
		{
			StartGrowing();
		}else{
			fruitState = FruitStates.OnGround;
		}
		
		germinated = false;
	}
	
	void Update () {
		if (fruitState == FruitStates.OnGround && rb.velocity == Vector2.zero && germinated == true && planting == false)
		{
			// Debug.Log("CANGROW");
			StartCoroutine("Planting");
		}
	}
	
	public void StartGrowing () {
		StartCoroutine("Grow");
	}
	
	public void StopGrowing () {
		StopCoroutine("Grow");
	}
	
	IEnumerator Grow () {
		
		fruitState = FruitStates.Growing;
		
		currentGrowth = 0;
		// transform.localScale = new Vector2(minSize, minSize);
		transform.localScale = minSize;
		
		timeUntilFall = 0;
		
		while (timeUntilFall < fallTime && fruitState == FruitStates.Growing)
		{
			transform.localScale = Vector3.Lerp(minSize, maxSize, timeUntilFall / fallTime);
			
			timeUntilFall += Time.deltaTime;
			yield return null;
		}
		
		if (fruitState == FruitStates.Growing)
		{
			Drop();
		}
	}
	
	void Drop () {
		fruitState = FruitStates.OnGround;
		transform.Translate(Vector3.down * 0.5f);
	}
	
	public override void PickUpE () {
		// base.PickUpE();
		
		fruitState = FruitStates.Held;
		germinated = true;
		planting = false;
	}
	
	public override void Dropped () {
		fruitState = FruitStates.OnGround;
	}
	
	// public void Shake () {
	
	// }
	
	IEnumerator Planting () {
		planting = true;
		
		float t = 0;
		
		while (t < plantTime && fruitState == FruitStates.OnGround) {
			
			t += Time.deltaTime;
			yield return null;
		}
		
		if (fruitState == FruitStates.OnGround)
		{
			Instantiate(tree, transform.position, Quaternion.identity);
			gameObject.SetActive(false);
		}
	}
	
	public void Eat () {
	
	}
	
	public void Plant () {
	
	}
	
	public void AddToCauldron () {
	
	}
}
