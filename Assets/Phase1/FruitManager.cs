using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class FruitManager : MonoBehaviour {
	
	public enum FruitType {
		speedFruit,
		damageFruit,
		healthFruit
	} FruitType fruitType;
	
	[System.Serializable]
	public class Fruits {
		public float maxIncrease;
		public Color color;
		public Sprite sprite;
	} public Fruits speedFruit, damageFruit, healthFruit;
	
	// public GameObject obj;
	public GameObject speedFruitObj;
	public GameObject damageFruitObj;
	public GameObject healthFruitObj;
	public GameObject treeObj;
	public int amountOfObj = 15;
	
	// private ObjectPool objects;
	// private ObjectPool speedFruitOP;
	// private ObjectPool damageFruitOP;
	// private ObjectPool healthFruitOP;
	private ObjectPool treeOP;
	
	Dictionary<string, ObjectPool> fruitPools;
	
	void Awake () {
		treeOP = gameObject.AddComponent<ObjectPool>();
		treeOP.SetUp(amountOfObj, treeObj, true);
		
		ObjectPool speedFruitOP = gameObject.AddComponent<ObjectPool>();
		speedFruitOP.SetUp(amountOfObj, speedFruitObj, true);
		
		ObjectPool damageFruitOP = gameObject.AddComponent<ObjectPool>();
		damageFruitOP.SetUp(amountOfObj, damageFruitObj, true);
		
		ObjectPool healthFruitOP = gameObject.AddComponent<ObjectPool>();
		healthFruitOP.SetUp(amountOfObj, healthFruitObj, true);
		
		fruitPools = new Dictionary<string, ObjectPool>();
		
		fruitPools.Add("Speed", speedFruitOP);
		fruitPools.Add("Damage", damageFruitOP);
		fruitPools.Add("Health", healthFruitOP);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	// public void MakeNewFruit (FruitType newFruit, Vector2 pos) {
	public GameObject GetNewFruit (string fruit, Vector2 pos) {
		
		// Debug.Log(fruit);
		GameObject go = fruitPools[fruit].GetObject();
		
		go.SetActive(true);
		go.transform.position = pos;
		
		// go.GetComponent<Fruit>().SetUp(true);
		// go.GetComponent<SpriteRenderer>().sprite = 
		
		return go;
	}
	
	// public GameObject GetNewSpeedFruit (Vector2 pos) {
		// GameObject go = speedFruitOP.GetObject();
		// go.SetActive(true);
		// go.transform.position = pos;
		// // go.GetComponent<Fruit>().SetUp(true);
		// // go.GetComponent<SpriteRenderer>().sprite = 
		
		// return go;
	// }
	
	// public GameObject GetNewHealthFruit (Vector2 pos) {
		// GameObject go = healthFruitOP.GetObject();
		// go.SetActive(true);
		// go.transform.position = pos;
		// // go.GetComponent<Fruit>().SetUp(true);
		// // go.GetComponent<SpriteRenderer>().sprite = 
		
		// return go;
	// }
	
	// public GameObject GetNewDamageFruit (Vector2 pos) {
		// GameObject go = damageFruitOP.GetObject();
		// go.SetActive(true);
		// go.transform.position = pos;
		// // go.GetComponent<Fruit>().SetUp(true);
		// // go.GetComponent<SpriteRenderer>().sprite = 
		
		// return go;
	// }
	
	public GameObject GetNewTree (Vector2 pos) {
		GameObject go = treeOP.GetObject();
		go.SetActive(true);
		go.transform.position = pos;
		// go.GetComponent<Fruit>().SetUp(true);
		// go.GetComponent<SpriteRenderer>().sprite = 
		
		return go;
	}
	
}
