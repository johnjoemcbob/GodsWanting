using UnityEngine;
using System.Collections;

public class Grabber : MonoBehaviour {

	public Rigidbody rb;
	// public HingeJoint hinge;
	
	void OnTriggerEnter (Collider other) {
		
		Connector c = other.gameObject.GetComponent<Connector>();
	
		if (c != null)
		{
			other.transform.SetParent(transform);
			other.transform.localPosition = new Vector3(0.0f, -0.5f, 0);
			
			Debug.Log("G");
			c.Grabbed();
			
			// if (other.gameObject.GetComponent<FixedJoint>() == null)
			// {
				// other.gameObject.AddComponent<FixedJoint>();  
				// other.gameObject.GetComponent<FixedJoint>().connectedBody = rb;
			// }
			
			// Debug.Break();
			
			// hinge.connectedBody = other.gameObject.GetComponent<Rigidbody>();
			
			// float newX = Random.Range(-0.5f, 0.5f);
			// float newZ = 0.6f - Mathf.Abs(newX);
			
			// newZ = Random.Range(0, 2) == 0 ? newZ : -newZ;
			
			// other.transform.localPosition = new Vector3(newX, 0, newZ);
			// other.transform.localPosition = new Vector3(0.6f, 0, 0);
			// other.transform.localPosition = new Vector3(0.0f, -0.5f, 0);
			
		}
	}
}
