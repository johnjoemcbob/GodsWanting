using UnityEngine;
using System.Collections;

public class LegController : MonoBehaviour {
	
	public float speed = 0.01f;
	
	private Transform[] legs;
	
	// Use this for initialization
	void Start () {
		legs = GetComponentsInChildren<Transform>();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKey("d"))
		{
			for (int i = 0; i < legs.Length; i+=2)
			{
				legs[i].RotateAround(Vector3.one, speed);
			}
		}
		if (Input.GetKey("a"))
		{
			for (int i = 1; i < legs.Length; i+=2)
			{
				legs[i].RotateAround(Vector3.one, -speed);
			}
		}
	}
}
