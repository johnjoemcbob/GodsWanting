﻿using UnityEngine;
using System.Collections;

public class DroneControl : MonoBehaviour {
	
	public float upPowerMin;
	public float upPowerMax;
	public float turnSpeed;
	
	public float maxSpeed;
	
	private int playerNum = 0;
	
	private Rigidbody rb;
	
	public Transform target;
	
	private float bladePower;
 
    float xAxis;
    float yAxis;
	
	void Awake () {
		rb = GetComponent<Rigidbody>();
	}
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		
		bladePower = (Input.GetAxis("Thrust_"+playerNum) + 1) / 2;
	
		Vector3 direction = new Vector3(Input.GetAxis ("Horizontal"), 0, Input.GetAxis ("Vertical"));
		if(direction.magnitude > 0.1f)
		{
			// SO CLOSE
			transform.Rotate(Vector3.forward * direction.x * -turnSpeed * Time.deltaTime, Space.World );
			transform.Rotate(Vector3.right * direction.z * turnSpeed * Time.deltaTime, Space.World );
			
			// transform.Rotate(direction.z, 0, -direction.x);
			// transform.Rotate(direction.z, 0, -direction.x, Space.World);
			
			// float rotateAmount = turnSpeed * -Mathf.Sign(Input.GetAxis("Horizontal"));
			// transform.Rotate(Vector3.forward * rotateAmount * Time.deltaTime);
			
			 // var direction = (objectHit.transform.position - transform.position).normalized;
     // transform.up = direction;
			
			  // var targetRotation = Quaternion.FromToRotation(Vector3.forward, Vector3.up) * Quaternion.LookRotation(direction);
      // transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, Time.deltaTime * turnSpeed);
	  
			// Vector3 targetDir = target.position - transform.position;
			// Vector3 targetDir = direction;
			
			
			// float step = turnSpeed * Time.deltaTime;
			// Vector3 newDir = Vector3.RotateTowards(transform.forward, targetDir, step, 0.0F);
			// Debug.DrawRay(transform.position, newDir, Color.red);
			// transform.rotation = Quaternion.LookRotation(newDir);
			// transform.eulerAngles = new Vector3(0, 90, 0);
			
			// transform.LookAt(target);
			// Debug.Log(direction);
			
		}
		
		// direction = target.position - transform.position;
		// Quaternion toRotation = Quaternion.FromToRotation(transform.up, direction);
		// transform.rotation = Quaternion.Lerp(transform.rotation, toRotation, turnSpeed * Time.time);
	}
	
	void FixedUpdate () {
		
		
	
		// if (Input.GetButton("Fire_"+playerNum))
		// if (Input.GetAxis("Thrust_"+playerNum) > 0)
		// {
			// velocity.y = thrust;
			// rb.AddForce(transform.up * thrust);
			
			float thrust = upPowerMax * bladePower;
			rb.AddForce(transform.up * thrust);
			
			if (rb.angularVelocity != Vector3.zero)
			{
				rb.angularVelocity = Vector3.zero;
			}
		// }
		
		// float maxSpeed = 10;
		
		if(rb.velocity.magnitude > maxSpeed)
        {
			rb.velocity = rb.velocity.normalized * maxSpeed;
			Debug.Log("T");
        }
		
		// Debug.Log(bladePower);
	}
	
	public float GetThrust () {
		return bladePower;
	}
}
