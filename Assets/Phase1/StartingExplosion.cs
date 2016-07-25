using UnityEngine;
using System.Collections;

public class StartingExplosion : MonoBehaviour {
	
	public float minForce;
	public float maxForce;
	
	public int noOfEachFruit;
	
	private FruitManager fruitManager;
	
	void Awake () {
		fruitManager = GetComponent<FruitManager>();
	}
	
	// Use this for initialization
	void Start () {
		Explode();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	public void Explode () {
		
		for (int i = 0; i < noOfEachFruit; i++)
		{	
			FirePair("Speed");
			FirePair("Damage");
			FirePair("Health");
		}
		
		// for (int i = 0; i < loopNo; i++)
		// {	
			// go = fruitManager.GetNewSpeedFruit(transform.position);
			
			// // Vector2 randomDir = new Vector2(Random.value, Random.value);
			// Vector2 randomDir = new Vector2(Random.Range(-1f, 1f), Random.Range(-1f, 1f));
			// float randomForce = Random.Range(minForce, maxForce);
			
			// go.GetComponent<Fruit>().SetUp(false);
			// go.GetComponent<Fruit>().Fire(randomDir, randomForce);
			
			// go = fruitManager.GetNewSpeedFruit(transform.position);
			
			// go.GetComponent<Fruit>().SetUp(false);
			// go.GetComponent<Fruit>().Fire(-randomDir, randomForce);
		// }
		
		// for (int i = 0; i < loopNo; i++)
		// {	
			// go = fruitManager.GetNewDamageFruit(transform.position);
			
			// // Vector2 randomDir = new Vector2(Random.value, Random.value);
			// Vector2 randomDir = new Vector2(Random.Range(-1f, 1f), Random.Range(-1f, 1f));
			// float randomForce = Random.Range(minForce, maxForce);
			
			// go.GetComponent<Fruit>().SetUp(false);
			// go.GetComponent<Fruit>().Fire(randomDir, randomForce);
			
			// go = fruitManager.GetNewDamageFruit(transform.position);
			
			// go.GetComponent<Fruit>().SetUp(false);
			// go.GetComponent<Fruit>().Fire(-randomDir, randomForce);
		// }
		
		// for (int i = 0; i < loopNo; i++)
		// {	
			// go = fruitManager.GetNewHealthFruit(transform.position);
			
			// // Vector2 randomDir = new Vector2(Random.value, Random.value);
			// Vector2 randomDir = new Vector2(Random.Range(-1f, 1f), Random.Range(-1f, 1f));
			// float randomForce = Random.Range(minForce, maxForce);
			
			// go.GetComponent<Fruit>().SetUp(false);
			// go.GetComponent<Fruit>().Fire(randomDir, randomForce);
			
			// go = fruitManager.GetNewHealthFruit(transform.position);
			
			// go.GetComponent<Fruit>().SetUp(false);
			// go.GetComponent<Fruit>().Fire(-randomDir, randomForce);
		// }
	}
	
	void FirePair (string fruit) {
		
		GameObject go;
		
		go = fruitManager.GetNewFruit(fruit, transform.position);
			
		// Vector2 randomDir = new Vector2(Random.value, Random.value);
		Vector2 randomDir = new Vector2(Random.Range(-1f, 1f), Random.Range(-1f, 1f));
		float randomForce = Random.Range(minForce, maxForce);
		
		go.GetComponent<Fruit>().SetUp(false);
		go.GetComponent<Fruit>().Fire(randomDir, randomForce);
		
		go = fruitManager.GetNewFruit(fruit, transform.position);
		
		go.GetComponent<Fruit>().SetUp(false);
		go.GetComponent<Fruit>().Fire(-randomDir, randomForce);
	}
}
