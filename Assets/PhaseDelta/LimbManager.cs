using UnityEngine;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

public class LimbManager : MonoBehaviour {
	
	public class LimbData {
		public Color[] colors;
		public Vector3[] sizes;
		public Mesh[] meshes;
	}
	
	// [System.Serializable]
	// public class LimbType {
		// public string name;
		// public GameObject obj;
		
		// public ObjectPool objPool;
		
		// public LimbType (GameObject go){
			// obj = go;
			// // objPool = gameObject.AddComponent<ObjectPool>();
			// // objPool.SetUp(obj);
		// }
		
	// } public LimbType[] limbs;
	
	// public GameObject armObj;
	// public int amountOfObj = 15;
	
	// private ObjectPool arms;
	// private Dictionary<string, ObjectPool> limbPools;
	private List<ObjectPool> limbPools;
	// private List<LimbType> limbPools;
	private GameObject[] limbs;
	
	void Awake () {
		
		// limbs = (GameObject[])Resources.LoadAll("Limbs");
		// limbs = Resources.LoadAll("Limbs", typeof(GameObject)) as GameObject[];
		// limbs = Resources.LoadAll("Limbs", typeof(GameObject)).Cast<GameObject[]>();
		limbs = Resources.LoadAll("Limbs", typeof(GameObject)).Cast<GameObject>().ToArray();
		// limbs = Resources.LoadAll("Limbs", typeof(GameObject));
		
		limbPools = new List<ObjectPool>();
		// limbPools = new List<LimbType>();
		
		// Debug.Log(limbs);
		
		for (int i = 0; i < limbs.Length; i++)
		{
			// limbPools.Add(new LimbType(limbs[i]));
			limbPools.Add(gameObject.AddComponent<ObjectPool>());
			limbPools[i].SetUp(limbs[i]);
		}
		
		// limbPools = new Dictionary<string, ObjectPool>();
		
		// objects = gameObject.AddComponent<ObjectPool>();
		// objects.SetUp(amountOfObj, obj, true);
	}
	
	public GameObject GetRandomLimb () {
		
		int l = Random.Range(0, limbPools.Count);
		
		// GameObject gO = limbPools[l].GetObject();
		// gO.SetActive(true);
		
		GameObject gO = Instantiate(limbs[0]) as GameObject;
		gO.SetActive(false);
		
		return gO;
		
	}
}
