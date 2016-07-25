using UnityEngine;
using System.Collections;

public class VehicleControl : MonoBehaviour {
	
	public float movementForce;
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 direction = new Vector3(Input.GetAxis ("Horizontal"), 0, Input.GetAxis ("Vertical"));
		if(direction.magnitude > 0.1f)
		{
			Quaternion rotation = Quaternion.LookRotation(direction, Vector3.up);
			transform.rotation = rotation;
		}
		// GetComponent<Rigidbody>().AddForce(transform.right * 50);
		// if (Input.GetButton("Fire_0"))
		// {
			// GetComponent<Rigidbody>().AddForce(transform.right * 10);
		// }
	}
	
	void FixedUpdate () {
		if (Input.GetButton("Fire_0"))
		{
			GetComponent<Rigidbody>().AddForce(transform.forward * movementForce);
		}
	}
}
