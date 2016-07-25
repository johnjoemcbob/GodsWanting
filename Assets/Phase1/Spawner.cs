using UnityEngine;
using System.Collections;

public class Spawner : MonoBehaviour {
	
	public GameObject obj;
	public int amountOfObj = 15;
	
	private ObjectPool objects;
	
	void Awake () {
		objects = gameObject.AddComponent<ObjectPool>();
		objects.SetUp(amountOfObj, obj, true);
	}
	
	public virtual void SpawnObject () {
		
		// Vector2 spawnPos = Vector2.zero;
		// GameObject objClone = Instantiate(obj, spawnPos, transform.rotation) as GameObject;
		
		GameObject go = objects.GetObject();
		
		go.SetActive(true);
		go.transform.position = Vector2.zero;
		go.transform.rotation = Quaternion.identity;
		
	}
}
