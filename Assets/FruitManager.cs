using UnityEngine;
using System.Collections;

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
	
	public GameObject obj;
	public int amountOfObj = 15;
	
	private ObjectPool objects;
	
	void Awake () {
		objects = gameObject.AddComponent<ObjectPool>();
		objects.SetUp(amountOfObj, obj, true);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	// public void MakeNewFruit (FruitType newFruit, Vector2 pos) {
	public void GetNewFruit (Vector2 pos) {
		GameObject go = objects.GetObject();
		go.SetActive(true);
		go.transform.position = pos;
		go.GetComponent<Fruit>().SetUp(true);
		// go.GetComponent<SpriteRenderer>().sprite = 
		
	}
}
