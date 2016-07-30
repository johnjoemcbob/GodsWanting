using UnityEngine;
using System.Collections;

public class Spawner : MonoBehaviour {
	
	public bool useSpawnerPos;
	
	public GameObject obj;
	public int amountOfObj = 15;
	
	private ObjectPool objects;
	
	private Vector3 spawnPos;
	
	void Awake () {
		objects = gameObject.AddComponent<ObjectPool>();
		objects.SetUp(amountOfObj, obj, true);
		
		spawnPos = useSpawnerPos ? transform.position : Vector3.zero;
	}
	
	public virtual void SpawnObject () {
		
		GameObject go = objects.GetObject();
		
		go.SetActive(true);
		go.transform.position = spawnPos;
		go.transform.rotation = Quaternion.identity;
		
	}
}
