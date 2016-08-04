using UnityEngine;
using System.Collections;

public class DroneControl : MovePerpendicularToCameraScript {
	
	
	public float upPowerMin;
	public float upPowerMax;
	public float turnSpeed;
	public float fineTurnSpeed;
	
	public float maxSpeed;
	public float fineMaxSpeed;
	
	public float distanceToRespawn;
	
	// private int playerNum = 0;
	
	private Rigidbody rb;
	// private LineRenderer line;
	// private Renderer lineR;
	
	private float currentTurnSpeed;
	private float currentMaxSpeed;
	
	private float bladePower;
 
	private bool isLasering;
	
	private Player playerScript;
	
	void Awake () {
		rb = GetComponent<Rigidbody>();
		// line = GetComponentInChildren<LineRenderer>();
		// lineR = line.GetComponent<Renderer>();
		
		// line.enabled = false;
		
		playerScript = GetComponent<Player>();
		
		CameraParent = GameObject.Find("Phase1Camera");
	}
	
	// Use this for initialization
	void Start () {
		currentTurnSpeed = turnSpeed;
		currentMaxSpeed = maxSpeed;
	}
	
	// Update is called once per frame
	void Update () {
		
		bladePower = (Input.GetAxis("Shoulder_2_"+playerScript.GetPlayerNum()) + 1) / 2;
	
		Vector3 direction = new Vector3(Input.GetAxis ("Stick_H_"+playerScript.GetPlayerNum()), 0, Input.GetAxis ("Stick_V_"+playerScript.GetPlayerNum()));
		
		direction = Move(direction);
		
		if(direction.magnitude > 0.1f)
		{
			// SO CLOSE
			if (isLasering == false)
			{
				transform.Rotate(Vector3.forward * direction.x * -currentTurnSpeed * Time.deltaTime, Space.World );
				transform.Rotate(Vector3.right * direction.z * currentTurnSpeed * Time.deltaTime, Space.World );	
			}else{
				transform.Rotate(Vector3.forward * direction.x * -currentTurnSpeed * Time.deltaTime);
				transform.Rotate(Vector3.right * direction.z * currentTurnSpeed * Time.deltaTime);
			}
		}
		
		 // transform.RotateAround(Vector3.zero, Vector3.up, 20 * Time.deltaTime);
		
		// if (Input.GetButtonDown("Dash_0")) 
		// {
			// StopCoroutine("FireBeam");
			// StartCoroutine("FireBeam");
		// }
		
		if (Vector3.Distance(Vector3.zero, transform.position) > distanceToRespawn)
		{
			transform.position = playerScript.GetPlayerSpawn();
			transform.rotation = Quaternion.identity;
			
			rb.angularVelocity = Vector3.zero;
			rb.velocity = Vector3.zero;
		}
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
		
		if(rb.velocity.magnitude > currentMaxSpeed)
        {
			rb.velocity = rb.velocity.normalized * currentMaxSpeed;
			// Debug.Log("T");
        }
		
		// Debug.Log(bladePower);
	}
	
	// IEnumerator FireBeam () {
		// line.enabled = true;
		
		// while (Input.GetButton("Dash_0"))
		// {
			// lineR.material.mainTextureOffset = new Vector2(0, Time.time);
		
			// Ray ray = new Ray (transform.position, -transform.up);
			// RaycastHit hit; 
			// Physics.Raycast(ray, out hit, 100);
			
			// if (hit.collider != null)
			// {
				// Laserable lase = hit.collider.GetComponent<Laserable>();
				// if (lase != null)
				// {
					// lase.StartLasering();
					// // Absorb(1);
				// }
			// }
			
			// line.SetPosition(0, ray.origin);
			
			// // if (Physics.Raycast(ray, out hit, 100))
			// if (hit.collider)
			// {
				// line.SetPosition(1, hit.point);
			// }else{
				// line.SetPosition(1, ray.GetPoint(100));
			// }
			
			// yield return null;
		// }
		
		// line.enabled = false;
	// }
	
	// public void Absorb (float scaleIncrease) {
		// transform.localScale += new Vector3(scaleIncrease, scaleIncrease, scaleIncrease); 
	// }
	
	public void LaserOn () {
		currentTurnSpeed = fineTurnSpeed;
		currentMaxSpeed = fineMaxSpeed;
		
		rb.isKinematic = true;
		isLasering = true;
	}
	
	public void LaserOff () {
		currentTurnSpeed = turnSpeed;
		currentMaxSpeed = maxSpeed;
		
		rb.isKinematic = false;
		isLasering = false;
	}
	
	public float GetThrust () {
		return bladePower;
	}
}
