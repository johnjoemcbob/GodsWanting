using UnityEngine;
using System.Collections;

public class TreeGrow : MonoBehaviour {
	
	public GameObject fruit;
	
	private GameObject currentlyGrowing;
	
	// Use this for initialization
	void Start () {
		InvokeRepeating("NewFruit", 0, 15);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void NewFruit () {
		GameObject.Find("Managers").GetComponent<FruitManager>().GetNewFruit(transform.position);
	}
	
	// IEnumerator StartGrowing () {
		
		// Vector2 spawnPos;
		
		// while (t < growTime)
		// {
			
		// }
		
	// }
}
