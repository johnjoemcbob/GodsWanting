using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class PlayerControl : MonoBehaviour {
	
	public float speed;
	public float dashSpeedIncrease;
	public float dashTime;
	public float dashCooldown;
	public float minShotStrength;
	public float maxShotStrength;
	public float shotForceIncrease;
	
	public float speedDecreaseForHeld;
	
	public float rotSpeed = 5;
	
	private float additionalSpeed;
	private float additionalDashTime;
	private float additionalStunRecovery;
	
	private List<GameObject> heldObjects = new List<GameObject>();
	
	private Vector2 lookDir;
	
	private float currentSpeed;
	private bool canDash;
	private bool isDashing;
	private bool aiming;
	
	private int playerNum = 0;
	private Color playerColor;
	
	private Rigidbody2D rb;
	
	private Image actionImage;
	
	void Awake () {
		rb = GetComponent<Rigidbody2D>();
		actionImage = GetComponentInChildren<Image>();
		// currentSpeed = speed;
		
		canDash = true;
	}
	
	public void SetUp (int pN, Color c)
	{
		playerNum = pN;
		playerColor = c;
		
		GetComponent<SpriteRenderer>().color = playerColor;
	}
	
	// Update is called once per frame
	void Update () {
		// Vector2 tempLookDir = new Vector2(Input.GetAxis("RightStick_H_"+playerNum), Input.GetAxis("RightStick_V_"+playerNum));
		lookDir = new Vector2(Input.GetAxis("RightStick_H_"+playerNum), Input.GetAxis("RightStick_V_"+playerNum));
		// if (lookDir.magnitude > 0.1f)
		// {
			// lookDir = tempLookDir;
			// float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg;
			// transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.AngleAxis(angle, Vector3.forward), Time.deltaTime * rotSpeed);	
			// rb.angularVelocity = 0;
		// }
		
		if (Input.GetButtonDown("Fire_"+playerNum))
		{
			if (heldObjects.Count > 0)
			{
				// StartCoroutine("Fire");
				
				heldObjects[0].GetComponent<Fruit>().Fire(lookDir, maxShotStrength);
				// Debug.Log(lookDir * maxShotStrength);
				heldObjects.RemoveAt(0);
			}
		}
		
		if (Input.GetButtonDown("Reload_"+playerNum))
		{
			if (heldObjects.Count > 0)
			{
				// StartCoroutine("Fire");
				
				heldObjects[0].GetComponent<Fruit>().Eat(this);
				// Eat(heldObjects[0]);
				heldObjects.RemoveAt(0);
			}else if (canDash) 
			{
				StartCoroutine("Dash");
			}
		}	
		
		if (Input.GetButtonDown("AltFire_"+playerNum))
		{
			if (heldObjects.Count > 0)
			{
				// StartCoroutine("Fire");
				
				if (heldObjects[0].GetComponent<Fruit>().Plant())
				{
					heldObjects.RemoveAt(0);
				}
			}
		}
		
		// lookDir = new Vector2(Input.GetAxis("RightStick_H_"+playerNum), Input.GetAxis("RightStick_V_"+playerNum));
		// if (lookDir.magnitude != 0.0f && heldObjects.Count > 0 && aiming == false)
		// {
			// Debug.Log(lookDir.magnitude);
			// // Debug.Log(lookDir.normalized);
			// Debug.Log(lookDir);
			// StartCoroutine("AltFire");
		// }
	}
	
	void FixedUpdate () {
		currentSpeed = speed + additionalSpeed - (speedDecreaseForHeld * heldObjects.Count);
		
		if (isDashing)
		{
			currentSpeed *= dashSpeedIncrease;
		}
		
		// Debug.Log(currentSpeed);
		
		float y = Input.GetAxis("LeftStick_V_"+playerNum);
		rb.AddForce(Vector2.up * y * currentSpeed);
		
		float x = Input.GetAxis("LeftStick_H_"+playerNum);
		rb.AddForce(Vector2.right * x * currentSpeed);
	}
	
	public void AddHeldObject (GameObject go) {
		heldObjects.Add(go);
		
		
	}
	
	// IEnumerator AltFire () {
		
		// aiming = true;
	
		// float shotForce = minShotStrength;
		
		// float lastLookDir = lookDir.magnitude;
		// while (lookDir.magnitude >= lastLookDir)
		// {
			// // shotForce = Mathf.Clamp(shotForce += (shotForceIncrease * Time.deltaTime), minShotStrength, maxShotStrength);
			// // Debug.Log(shotForce);
			
			// lastLookDir = lookDir.magnitude;
			// yield return null;
		// }
		
		// shotForce = maxShotStrength * lastLookDir;
		
		// Debug.Log(lastLookDir);
		
		// heldObjects[0].GetComponent<Ingredient>().Fire(lookDir, shotForce);
		// heldObjects.RemoveAt(0);
		
		// aiming = false;
	// }
	
	IEnumerator Fire () {
		float shotForce = minShotStrength;
		
		while (Input.GetButton("Fire_"+playerNum))
		{
			shotForce = Mathf.Clamp(shotForce += (shotForceIncrease * Time.deltaTime), minShotStrength, maxShotStrength);
			Debug.Log(shotForce);
			yield return null;
		}
		
		heldObjects[0].GetComponent<Ingredient>().Fire(lookDir, shotForce);
		heldObjects.RemoveAt(0);
	}
	
	// void Eat () {
		
	// }
	
	IEnumerator Dash () {
		canDash = false;
		isDashing = true;
		// currentSpeed = dashSpeed;
		
		// gameObject.layer = LayerMask.NameToLayer("Dash");
		
		float t = 0;
		
		// dashIndicator.color = Color.black;
		
		
		while (t < dashTime)
		{
			t += Time.deltaTime;
			yield return null;
		}
		
		isDashing = false;
		// currentSpeed = speed;
		// gameObject.layer = LayerMask.NameToLayer("Default");
		// delayDash = 0;
		t = 0;
		
		while (t < dashCooldown) 
		{
			// dashIndicator.color = Color.Lerp(Color.black, Color.white, t / dashCooldown);
			t += Time.deltaTime;
			yield return null;
		}
		
		// dashIndicator.color = Color.white;
		
		canDash = true;
	}
	
	public void IncreaseSpeed (float s) {
		additionalSpeed += s;
	}
	
	public void UpdateActionUI (float p) {
		actionImage.fillAmount = p;
		
		if (p == 1)
		{
			Invoke("ClearActionUI", 1);
		}
	}
	
	void ClearActionUI () {
		UpdateActionUI(0);
	}
}
