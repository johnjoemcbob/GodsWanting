using UnityEngine;
using System.Collections;

public class Connector : MonoBehaviour {
	
	private LimbManager limbManager;
	
	private HingeJoint hinge;
	// private JointMotor motor;
	private Rigidbody rb;
	
	private GameObject currentObject;
	private bool initialized;
	
	void Awake () {
		limbManager = GameObject.Find("Managers").GetComponent<LimbManager>();
		
		// hinge = GetComponent<HingeJoint>();
		// rb = GetComponentInChildren<Rigidbody>();
		rb = GetComponent<Rigidbody>();
		
		// motor = hinge.motor;
		
		if (transform.childCount > 0)
		{
			currentObject = transform.GetChild(0).gameObject;
			// currentObject.transform.SetParent(null);
		}
	}
	
	void OnEnable () {
		if (initialized)
		{
			// AddLimb();
			// currentObject.SetActive(true);
			// currentObject.transform.SetParent(null);
		}
	}
	
	void OnDisable () {
		if (currentObject != null)
		{
			// currentObject.SetActive(false);
			// currentObject.transform.SetParent(transform);
			
			// currentObject = null;
			rb.isKinematic = false;
		}
		
		if (initialized == false)
		{
			initialized = true;
		}
	}
	
	void OnTriggerEnter (Collider other) {
		if (other.gameObject.name == "Body")
		{
			Debug.Log("AttemptAttachYo");
		}
	}
	
	public void Grabbed () {
		rb.isKinematic = true;
		
		// hinge = gameObject.AddComponent<HingeJoint>();
		// hinge.connectedBody = droneRB;
		
		// hinge.useMotor = false;
		
		currentObject.GetComponent<Limb>().AttachToDrone();
	}
	
	void AddLimb () {
		if (currentObject == null)
		{
			currentObject = limbManager.GetRandomLimb();
			currentObject.SetActive(true);
			// currentObject.transform.SetParent(transform);
			
			currentObject.GetComponent<Limb>().SetUp(rb);
			
			// hinge = GetComponentInChildren<HingeJoint>();
			// hinge.connectedBody = rb;
		}
	}
	
	void ClearLimb () {
		
	}
}
