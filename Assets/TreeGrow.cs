using UnityEngine;
using System.Collections;

public class TreeGrow : MonoBehaviour {
	
	private string fruitType;
	
	private FruitManager fruitManager;
	
	void Awake () {
		fruitManager = GameObject.Find("Managers").GetComponent<FruitManager>();
	}
	
	// private GameObject currentlyGrowing;
	
	// Use this for initialization
	// void Start () {
		// InvokeRepeating("NewFruit", 0, 15);
	// }
	
	public void SetUp (string v) {
		InvokeRepeating("NewFruit", 0, 15);
		
		fruitType = v;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void NewFruit () {
		fruitManager.GetNewFruit(fruitType, transform.position);
	}
	
	// IEnumerator StartGrowing () {
		
		// Vector2 spawnPos;
		
		// while (t < growTime)
		// {
			
		// }
		
	// }
}
