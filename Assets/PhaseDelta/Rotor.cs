using UnityEngine;
using System.Collections;

public class Rotor : MonoBehaviour {

	public float initRotSpeed;
	public float rotSpeedMultiplier;
	public float rotSpeedMin;
	public float rotSpeedMax;
	
	private Rigidbody rb;
	
	void Awake () {
		rb = transform.parent.GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
		float rotSpeed = initRotSpeed;
	
		// rotSpeed = initRotSpeed * (rotSpeedMultiplier * rb.velocity.y);
		// rotSpeed = Mathf.Clamp(rotSpeedMultiplier * Mathf.Abs(rb.velocity.y), rotSpeedMin, rotSpeedMax);
		rotSpeed = Mathf.Clamp(rotSpeedMultiplier * Mathf.Abs(rb.velocity.magnitude), rotSpeedMin, rotSpeedMax);
		// rotSpeed = Mathf.Clamp(rotSpeedMultiplier * rb.velocity.y, -rotSpeedMax, rotSpeedMax);
		
		// rotSpeed = initRotSpeed * Mathf.Sign(rb.velocity.y);
	
		transform.Rotate(Vector3.up * rotSpeed * Time.deltaTime);
		// transform.Rotate(Vector3.up * initRotSpeed * Time.deltaTime);
	}
}
