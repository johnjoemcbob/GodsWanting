using UnityEngine;
using System.Collections;

public class Body : MonoBehaviour {

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
			if (gameObject.GetComponent<FixedJoint>() == null)
			{
				gameObject.AddComponent<FixedJoint>();  
				gameObject.GetComponent<FixedJoint>().connectedBody = other.gameObject.GetComponent<Rigidbody>();
			}
		}
	}
}
