using UnityEngine;
using System.Collections;

public class LaserableParent : MonoBehaviour {
	
	// private int 
	// private bool 
	
	public float laseTime = 1;
	public GameObject laseTarget;
	
	private Rigidbody rb;
	
	void Awake () {
		rb = GetComponent<Rigidbody>();
		
		if (laseTarget == null)
		{
			laseTarget = gameObject;
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	public void StartLasering (Laser l) {
		// Lase();
		StartCoroutine("Laserr", l);
		// return laseTarget;
	}
	
	public void StopLasering () {
		StopCoroutine("Laserr");
	}
	
	IEnumerator Laserr (Laser l) {
		
		// rb.isKinematic = true;
		float t = 0;
		
		// while (true)
		while (t < laseTime)
		{
			t += Time.deltaTime;
			// Debug.Log(t);
			yield return null;
		}
		
		Lase(l);
	}
	
	public void Lase (Laser l) {
		// gameObject.SetActive(false);
		l.Absorb(gameObject);
	}
}
