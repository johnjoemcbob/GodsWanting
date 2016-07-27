using UnityEngine;
using System.Collections;

public class Grabber : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void OnTriggerEnter (Collider other) {
		
		Connector c = other.gameObject.GetComponent<Connector>();
	
		if (c != null)
		{
			other.transform.SetParent(transform);
			
			c.Grabbed();
			
			float newX = Random.Range(-0.5f, 0.5f);
			float newZ = 0.6f - Mathf.Abs(newX);
			
			newZ = Random.Range(0, 2) == 0 ? newZ : -newZ;
			
			// other.transform.localPosition = new Vector3(newX, 0, newZ);
			other.transform.localPosition = new Vector3(0.6f, 0, 0);
			
		}
	}
}
