using UnityEngine;
using System.Collections;

public class Fruit : PickUpAble {
	
	// public GameObject tree;
	
	public float effectChange;
	
	public Vector3 minSize;
	public Vector3 maxSize;
	
	public float timeUntilFall;
	public float fallTime;
	public float plantTime;
	
	public int pressesToPlant;
	private int currentPresses;
	
	private float currentGrowth;
	private bool germinated;
	private bool planting;
	private bool bubbling;
	private bool inCauldron;
	
	[HideInInspector]
	public Cauldron currentCauldron;
	[HideInInspector]
	public float growthPercentage;
	[HideInInspector]
	public string fruitType;
	
	private FruitManager fruitManager;
	
	public enum FruitStates {
		Growing,
		OnGround,
		Held,
		InCauldron
	} public FruitStates fruitState;
	
	private Transform startingParent;
	
	public override void Awake () {
		base.Awake();
	
		fruitManager = GameObject.Find("Managers").GetComponent<FruitManager>();
		startingParent = transform.parent;
	}
	
	public void SetUp (bool fromTree) {
		if (fromTree)
		{
			StartGrowing();
			germinated = false;
		}else{
			fruitState = FruitStates.OnGround;
			germinated = true;
		}
		
		inCauldron = false;
	}
	
	void Update () {
		if (fruitState == FruitStates.OnGround && rb.velocity == Vector2.zero && germinated == true && planting == false && bubbling == false)
		{
			// Debug.Log("CANGROW");
			IsStationary();
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
			growthPercentage = timeUntilFall / fallTime;
			transform.localScale = Vector3.Lerp(minSize, maxSize, growthPercentage);
			
			timeUntilFall += Time.deltaTime;
			yield return null;
		}
		
		if (fruitState == FruitStates.Growing)
		{
			growthPercentage = 1;
			transform.localScale = maxSize;
			
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
		bubbling = false;
	}
	
	public override void Dropped () {
		fruitState = FruitStates.OnGround;
	}
	
	// public void Shake () {
	
	// }
	
	public void IsStationary () {
		if (inCauldron == false)
		{
			StartCoroutine("Planting");
		}else{
			AddToCauldron();
		}
	}
	
	IEnumerator Planting () {
		
		// Vector3 startPos = transform.position;
		
		planting = true;
		
		float t = 0;
		
		while (fruitState == FruitStates.OnGround)
		{
		// while (t < plantTime && fruitState == FruitStates.OnGround) {
			while (t < plantTime) 
			{
				
				t += Time.deltaTime;
				yield return null;
			}
		
		// Debug.Log("D");
		
		// if (startPos == transform.position)
		// {
			// Instantiate(tree, transform.position, Quaternion.identity);
			GameObject go = fruitManager.GetNewTree(transform.position);
			go.GetComponent<TreeGrow>().SetUp(fruitType);
			
			gameObject.SetActive(false);
		// }
			yield return null;
		}
	}
	
	IEnumerator PlayerPlanting () {
		
		Vector3 startPos = transform.position;
		
		planting = true;
		currentPresses = 0;
		
		float marginOfError = 0.5f;
		
		// float t = 0;
		
		while (Vector2.Distance(startPos,transform.position) < marginOfError)
		{
			yield return null;
		}
		
		// Debug.Log("D");
		
		planting = false;
		currentPresses = 0;
		currentPlayerScript.UpdateActionUI(0);
	}
	
	public void Eat () {
	
	}
	
	public bool Plant () {
		if (planting == false)
		{
			StartCoroutine("PlayerPlanting");
		}
		currentPresses++;
		currentPlayerScript.UpdateActionUI((float)currentPresses/(float)pressesToPlant);
		
		if (currentPresses >= pressesToPlant)
		{
			PlantTree();
			return true;
		}
		
		// Debug.Log(currentPresses);
		return false;
	}
	
	void PlantTree ( ){
		GameObject go = fruitManager.GetNewTree(transform.position);
		go.GetComponent<TreeGrow>().SetUp(fruitType);
			
		gameObject.SetActive(false);
	}
	
	public virtual void AddToCauldron () {
		bubbling = true;
		gameObject.SetActive(false);
	}
	
	public override void OnTriggerEnter2D (Collider2D other) {
		
		base.OnTriggerEnter2D(other);
		
		if (other.gameObject.tag == "Cauldron")
		{
			inCauldron = true;
			
			currentCauldron = other.GetComponent<Cauldron>();
		}
	}
	
	void OnTriggerExit2D (Collider2D other) {
		if (other.gameObject.tag == "Cauldron")
		{
			inCauldron = false;
			bubbling = false;
			
			currentCauldron = null;
		}
	}
	
	void OnDisable () {
		Invoke("Reparent", 0);
	}
	
	void Reparent () {
		transform.SetParent(startingParent);
	}
}
