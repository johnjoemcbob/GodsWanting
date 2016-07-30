using UnityEngine;
using System.Collections;
using System.Collections;

public class LimbArm : Limb {
	
	public float minScale;
	public float maxScale;
	
	public Rigidbody upperRB;
	public Rigidbody foreRB;
	public Rigidbody fistRB;
	
	private HingeJoint hinge;
	
	
	// private float newScale = 1;
	
	// void OnEnable () {
	void Awake () {
		hinge = GetComponentInChildren<HingeJoint>();
		
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
}
