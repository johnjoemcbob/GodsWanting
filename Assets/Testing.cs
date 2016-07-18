using UnityEngine;
using System.Collections;

public class Testing : MonoBehaviour {
	
	// private bool debug;
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetButtonDown("Debug"))
		{
			Debug.Break();
		}
	}
}
