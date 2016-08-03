﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class LimbArm : Limb {
	
	public float minScale;
	public float maxScale;
	
	public float flailForce;
	
	public Rigidbody upperRB;
	public Rigidbody foreRB;
	public Rigidbody fistRB;
	
	private HingeJoint hinge;
	
	private List<Vector3> startingPositions;
	
	// private float newScale = 1;
	
	// void OnEnable () {
	void Awake () {
		hinge = GetComponentInChildren<HingeJoint>();
		
		startingPositions = new List<Vector3>();
		
		// foreach (Transform t in GetComponentsInChildren<Transform>())
		// {
			// startingPositions.Add(t.position);
		// }
		
		for (int i = 0; i < transform.childCount; i++)
		{
			startingPositions.Add(transform.GetChild(i).localPosition);
		}
		
		// Debug.Log(startingPositions.Count);
		// Debug.Log(transform.GetChild(1));
		
		
	}
	
	void Update () {
		if (Input.GetKeyDown("e"))
		{
			DeactivateMotion();
		}
	}
	
	public override void SetUp (Rigidbody connectorRB) {
		hinge.connectedBody = connectorRB;
		
		// float newScale = Random.Range(minScale, maxScale);
		float newScale = Random.Range(1, 3);
		// Debug.Log(newScale);
		
		transform.localScale = new Vector3(newScale, newScale, newScale);
		// newScale++;
		// Debug.Log("ON");
		// foreach (Transform child in transform)
		// {
			// child.localScale = new Vector3(newScale, newScale, newScale);
	}
	
	
	public override void AttachToDrone () {
		// hinge.useMotor = false;
		// upperRB.velocity = Vector3.zero;
		
		// upperRB.isKinematic = true;
		// foreRB.isKinematic = true;
		// fistRB.isKinematic = true;
	}
	
	public override void ActivateMotion () {
		// hinge.useMotor = true;
		
		upperRB.useGravity = false;
		foreRB.useGravity = true;
		fistRB.useGravity = true;
		
		InvokeRepeating("Flail", 3, 3);
	}
	
	public override void DeactivateMotion () {
		
		Debug.Log("DeactivateMotion");
		
		if (hinge)
		{
			hinge.useMotor = false;
		}
		
		upperRB.velocity = Vector3.zero;
		foreRB.velocity = Vector3.zero;
		fistRB.velocity = Vector3.zero;
		
		upperRB.angularVelocity = Vector3.zero;
		foreRB.angularVelocity = Vector3.zero;
		fistRB.angularVelocity = Vector3.zero;
		
		// for (int i = 0; i < transform.childCount; i++)
		// {
			// transform.GetChild(i).localPosition = startingPositions[i];
		// }
		
		// foreach (Collider c in GetComponentsInChildren<Collider>())
		// {
			// c.isTrigger = true;
		// }
		
		upperRB.useGravity = false;
		foreRB.useGravity = false;
		fistRB.useGravity = false;
	}
	
	void Flail () {
		Debug.Log("Flail");
		fistRB.AddForce((GameObject.Find("Target").transform.position - transform.position) * flailForce);
	}
}
