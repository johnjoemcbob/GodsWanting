using UnityEngine;
using System.Collections;

public class Rotor : MonoBehaviour {

	public float initRotSpeed;
	public float rotSpeedMultiplier;
	public float rotSpeedMin;
	public float rotSpeedMax;
	
	private Rigidbody rb;
	private DroneControl controlScript;
	
	void Awake () {
		rb = transform.parent.GetComponent<Rigidbody>();
		controlScript = transform.parent.GetComponent<DroneControl>();
	}
	
	// Update is called once per frame
	void Update () {
		float rotSpeed = initRotSpeed;

		// rotSpeed = Mathf.Clamp(rotSpeedMultiplier * Mathf.Abs(rb.velocity.magnitude), rotSpeedMin, rotSpeedMax);
		// rotSpeed = Mathf.Clamp(rotSpeedMultiplier * Mathf.Abs(controlScript.GetThrust()), rotSpeedMin, rotSpeedMax);
		
		float m = Mathf.Max(Mathf.Abs(controlScript.GetThrust()), Mathf.Abs(rb.velocity.magnitude));
		
		rotSpeed = Mathf.Clamp(rotSpeedMultiplier * m, rotSpeedMin, rotSpeedMax);
		
	
		transform.Rotate(Vector3.up * rotSpeed * Time.deltaTime);
	}
}
