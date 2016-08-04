using UnityEngine;
using System.Collections;

public class SpawnTimer : MonoBehaviour {
	
	public float minSpawnTime;
	public float maxSpawnTime;
	
	private Spawner spawnerScript;
	
	private float objectSpawnInterval;
	
	void Awake () {
		spawnerScript = GetComponent<Spawner>();
		
		objectSpawnInterval = Random.Range(minSpawnTime/2,maxSpawnTime/2);
		
		StartCoroutine("ObjectSpawnerTimer");
	}
	
	public void StartSpawning () {
		StartCoroutine("ObjectSpawnerTimer");
	}
	
	public void StopSpawning () {
		StopCoroutine("ObjectSpawnerTimer");
	}
	
	public IEnumerator ObjectSpawnerTimer () {
		// while (GameStates.GetState() == "Playing")
		while (true)
		{
			yield return new WaitForSeconds(objectSpawnInterval);

			spawnerScript.SpawnObject();
			spawnerScript.SpawnObject();
			spawnerScript.SpawnObject();
			// spawnerScript.SpawnObject();
			// spawnerScript.SpawnObject();
			// spawnerScript.SpawnObject();
			// spawnerScript.SpawnObject();
			
			objectSpawnInterval = Random.Range(minSpawnTime, maxSpawnTime);
			
		}
		
		yield return null;

	}
	
}
