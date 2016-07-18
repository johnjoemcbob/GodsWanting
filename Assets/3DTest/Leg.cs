using UnityEngine;
using System.Collections;

public class Leg : MonoBehaviour {
		
	private int leg;
		
	// Use this for initialization
	void Start () {
		leg = Random.Range(0,4);
	}
	
	// Update is called once per frame
	void Update () {
		// transform.RotateAround(Vector3.one, 0.01f);
	}
}
