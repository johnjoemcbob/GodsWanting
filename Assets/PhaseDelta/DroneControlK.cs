using UnityEngine;
using System.Collections;

public class DroneControlK : MonoBehaviour {
	
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
		}
		
		float thrust = upPowerMax * bladePower;
		// rb.MovePosition(transform.up * thrust);
		
	}
	
	
	
	public float GetThrust () {
		return bladePower;
	}
}
