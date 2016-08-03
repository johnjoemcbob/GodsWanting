using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Cannon : MonoBehaviour {
	
	public GameObject topParent;
	public Laser laserScript;
	
	public float fireForce;

	private List<GameObject> ammo;
	
	private Player playerScript;
	
	void Awake () {
		ammo = new List<GameObject>();
		
		playerScript = GetComponentInParent<Player>();
	}
	
	void Update () {
		if (Input.GetButtonDown("Stick_In_"+playerScript.GetPlayerNum()))
		{
			Fire();
		}
	}

	public void AddToAmmo (GameObject GO) {
		ammo.Add(GO);
		GO.SetActive(false);
	}
	
	void Fire () {
		if (ammo.Count > 0)
		{
			Deflate();
			laserScript.NullifyLaser(ammo[ammo.Count-1]);
			
			ammo[ammo.Count-1].SetActive(true);
			
			ammo[ammo.Count-1].transform.position = transform.position + -transform.up * 1;
			
			ammo[ammo.Count-1].GetComponent<Rigidbody>().AddForce(-transform.up * fireForce);
			
			// Debug.Break();
			
			ammo.RemoveAt(ammo.Count-1);
		}
	}
	
	public void Deflate (float scaleDecrease = 0.4f) {
		topParent.transform.localScale -= new Vector3(scaleDecrease, scaleDecrease, scaleDecrease); 
	}
}
