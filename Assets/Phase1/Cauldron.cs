using UnityEngine;
using System.Collections;

public class Cauldron : MonoBehaviour {

	public Concoction p;
	
	void Awake () {
		p = new Concoction();
	}
	
	public void IncreaseSpeed (float v) {
		p.speed += v;
		// Debug.Log(v);	
	}
	
	public void IncreaseHealth (float v) {
		p.health += v;
		// Debug.Log(v);	
	}
	
	public void IncreaseDamage (float v) {
		p.damage += v;
		// Debug.Log(v);
	}
}
