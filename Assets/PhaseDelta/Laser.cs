using UnityEngine;
using System.Collections;

public class Laser : MonoBehaviour {
	
	public GameObject topParent;
	public Cannon cannon;
	
	private LineRenderer line;
	private Renderer lineR;
	private DroneControl controlScript;
	
	private GameObject currentTarget;
	private GameObject cannotTarget;
	
	void Awake () {
		line = GetComponent<LineRenderer>();
		lineR = line.GetComponent<Renderer>();
		controlScript = GetComponentInParent<DroneControl>();
		
		line.enabled = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetButtonDown("Dash_0")) 
		{
			StopCoroutine("FireBeam");
			StartCoroutine("FireBeam");
		}
	}
	
	IEnumerator FireBeam () {
		line.enabled = true;
		controlScript.LaserOn();
		
		while (Input.GetButton("Dash_0"))
		{
			lineR.material.mainTextureOffset = new Vector2(0, Time.time);
		
			Ray ray = new Ray (transform.position, -transform.up);
			RaycastHit hit; 
			Physics.Raycast(ray, out hit, 100);
			
			AttemptToLase(hit);
			
			line.SetPosition(0, ray.origin);
			
			// if (Physics.Raycast(ray, out hit, 100))
			if (hit.collider)
			{
				line.SetPosition(1, hit.point);
			}else{
				line.SetPosition(1, ray.GetPoint(100));
			}
			
			yield return null;
		}
		
		line.enabled = false;
		controlScript.LaserOff();
	}
	
	void AttemptToLase (RaycastHit hit) {
		if (hit.collider != null)
		{
			Laserable lase = hit.collider.GetComponent<Laserable>();
			if (lase != null)
			{
				if (hit.collider.gameObject != currentTarget && hit.collider.gameObject != cannotTarget)
				{
					if (currentTarget != null)
					{
						currentTarget.GetComponent<Laserable>().StopLasering();
					}
					
					currentTarget = hit.collider.gameObject;
					lase.StartLasering(this);
					// currentTarget = lase.StartLasering(this);
				}
			}else if (currentTarget != null)
			{
				currentTarget.GetComponent<Laserable>().StopLasering();
				currentTarget = null;
			}
		}
	}
	
	public void Absorb (GameObject GO, float scaleIncrease = 0.4f) {
		cannon.AddToAmmo(GO);
		topParent.transform.localScale += new Vector3(scaleIncrease, scaleIncrease, scaleIncrease); 
	}
	
	public void NullifyLaser (GameObject GO) {
		StartCoroutine("Disallow", GO);
	}
	
	IEnumerator Disallow (GameObject GO) {
		
		cannotTarget = GO;
		float t = 0;
		
		while (t < 0.5f) {
			
			t += Time.deltaTime;
			
			yield return null;
		}
		
		cannotTarget = null;
	}
}
