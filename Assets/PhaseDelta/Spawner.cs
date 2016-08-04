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
		
		spawnPos = new Vector3(Random.Range(-3, 3), 5, Random.Range(-3, 3));
		
		go.SetActive(true);
		go.transform.position = spawnPos;
		go.transform.rotation = Quaternion.identity;
		
	}
}
