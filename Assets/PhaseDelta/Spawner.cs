using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Spawner : MonoBehaviour {
	
	public bool useSpawnerPos;
	
	public GameObject obj;
	public int amountOfObj = 15;
	
	private ObjectPool objects;
	
	private Vector3 spawnPos;
	
	private List<Limb> spawnedLimbs;
	
	void Awake () {
		objects = gameObject.AddComponent<ObjectPool>();
		objects.SetUp(amountOfObj, obj, true);
		
		spawnPos = useSpawnerPos ? transform.position : Vector3.zero;
		
		spawnedLimbs = new List<Limb>();
	}
	
	public virtual void SpawnObject () {
		
		// GameObject go = objects.GetObject();
		
		// spawnPos = new Vector3(Random.Range(-3, 3), 5, Random.Range(-3, 3));
		
		// go.SetActive(true);
		// go.transform.position = spawnPos;
		// go.transform.rotation = Quaternion.identity;
		
		spawnPos = new Vector3(Random.Range(-3f, 3f), 5, Random.Range(-3f, 3f));
		GameObject go = Instantiate(obj, spawnPos, Quaternion.identity) as GameObject;
		spawnedLimbs.Add(go.GetComponent<Limb>());
		
	}
	
	public void Clear () {
		for (int i = 0; i < spawnedLimbs.Count; i++)
		{
			spawnedLimbs[i].AttemptClear();
		}
	}
}
