using UnityEngine;
using System.Collections;

public class TreeGrow : MonoBehaviour {
	
	public Vector2[] fruitPositions;
	
	public string fruitType;
	
	public float timeBetweenFruits;
	public int noOfFruitsToProduce;
	
	private int noOfFruitsProduced;
	
	private FruitManager fruitManager;
	
	void Awake () {
		fruitManager = GameObject.Find("Managers").GetComponent<FruitManager>();
	}
	
	// private GameObject currentlyGrowing;
	
	// Use this for initialization
	// void Start () {
		// InvokeRepeating("NewFruit", 0, timeBetweenFruits);
	// }
	
	void OnEnable () {
		noOfFruitsProduced = 0;
		if (fruitType != "")
		{
			InvokeRepeating("NewFruit", 1, timeBetweenFruits);
		}
	}
	
	public void SetUp (string v) {
		// InvokeRepeating("NewFruit", 0, timeBetweenFruits);
		
		fruitType = v;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void NewFruit () {
		fruitManager.GetNewFruit(fruitType, (Vector2)transform.position + fruitPositions[noOfFruitsProduced]);
		
		if (++noOfFruitsProduced == noOfFruitsToProduce)
		{
			CancelInvoke("NewFruit");
			Invoke("Deactivate", 5);
		}
	}
	
	void Deactivate () {
		gameObject.SetActive(false);
	}
	
	// IEnumerator StartGrowing () {
		
		// Vector2 spawnPos;
		
		// while (t < growTime)
		// {
			
		// }
		
	// }
}
