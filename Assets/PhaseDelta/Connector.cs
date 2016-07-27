using UnityEngine;
using System.Collections;

public class Connector : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void OnTriggerEnter (Collider other) {
		if (other.gameObject.name == "CollectRadius")
		{
			
		}
	}
	
	public void Grabbed () {
		GetComponent<Rigidbody>().isKinematic = true;
	}
}
