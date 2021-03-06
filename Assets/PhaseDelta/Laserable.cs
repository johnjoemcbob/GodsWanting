﻿using UnityEngine;
using System.Collections;

public class Laserable : MonoBehaviour {
	
	// private int 
	// private bool 
	
	public float laseTime = 1;
	// public GameObject laseTarget;
	
	[HideInInspector]
	public Rigidbody rb;
	
	private bool canLaser;
	
	public virtual void Awake () {
		rb = GetComponent<Rigidbody>();
		canLaser = true;
		// if (laseTarget == null)
		// {
			// laseTarget = gameObject;
		// }
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	public void StartLasering (Laser l) {
		// Lase();
		if (canLaser)
		{
			StartCoroutine("Laserr", l);
		}
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
	
	public virtual void Lase (Laser l) {
		// gameObject.SetActive(false);
		l.Absorb(gameObject);
	}
	
	public void CannotLaser () {
		canLaser = false;
	}
}
