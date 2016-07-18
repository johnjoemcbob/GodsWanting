using UnityEngine;
using System.Collections;

public class PickUpAble : MonoBehaviour {

	// private GameObject held
	
	private bool caught;
	
	private GameObject currentKeeper;
	
	private Collider2D col;
	[HideInInspector]
	public Rigidbody2D rb;
	
	void Awake () {
		col = GetComponent<Collider2D>();
		rb = GetComponent<Rigidbody2D>();
		
		// GetComponent<TrailRenderer>().startColor = GetComponent<SpriteRenderer>().color;
		// GetComponent<TrailRenderer>().endColor = GetComponent<SpriteRenderer>().color;
		// GetComponent<TrailRenderer>().material.SetColor("_TintColor", GetComponent<SpriteRenderer>().color);
	}
	
	// void Update () {
		// Debug.Log(rb.velocity);
	// }
	
	void OnTriggerEnter2D (Collider2D other) {
		if (other.gameObject.tag == "CatchRadius" && other.gameObject != currentKeeper) 
		{
			PickUp(other.transform);
			PickUpE();
		}
	}
	
	public virtual void PickUp (Transform col) {
		// col.enabled = false;
			// col.isTrigger = true;
			rb.isKinematic = true;
			// rb.velocity = Vector3.zero;
			
			transform.SetParent(col);
			transform.localPosition = Vector3.zero;
			
			// currentKeeper = other.gameObject;
			
			col.parent.GetComponent<PlayerControl>().AddHeldObject(gameObject);
	}
	
	public virtual void PickUpE () {
	
	}
	
	// void OnTriggerExit2D (Collider2D other) {
		// Debug.Log("D");
		// currentKeeper = null;
		// col.isTrigger = false;
	// }
	
	public void Fire (Vector2 dir, float force) {
		// col.enabled = true;
		// col.isTrigger = false;
		rb.isKinematic = false;
		transform.parent = null;
		rb.AddForce(dir * force);
		// rb.AddForce(dir * force, ForceMode2D.Impulse);
		Dropped();
	}
	
	public virtual void Dropped () {
	
	}
	
	public void Eat (PlayerControl player) {
		player.IncreaseSpeed(5);
		// Destroy(gameObject);
		gameObject.SetActive(false);
	}
	
	void OnCollisionEnter2D (Collision2D other) {
		if (other.gameObject.tag == "Frame")
		{
			// Debug.Log("D");
			// Debug.Log("RV " + other.relativeVelocity);
			
			// ContactPoint2D contact = other.contacts[0];
			// Vector3 newDir = Vector3.zero;
			// Vector3 curDir = transform.TransformDirection(Vector3.forward);
			// newDir = Vector3.Reflect(curDir, contact.normal);
			// transform.rotation = Quaternion.FromToRotation(Vector3.forward, newDir);
			
			// Debug.Break();
			
			// Vector2 newVel = new Vector2(rb.velocity.x, rb.velocity.y);
			// rb.velocity = newVel;
			// float y = -rb.velocity.y;
			// rb.velocity = new Vector2(rb.velocity.x, y);
			// rb.velocity = new Vector2(other.relativeVelocity.x, -other.relativeVelocity.y);
			
			Vector2 newVelocity = other.relativeVelocity;
			
			// Debug.Log(other.contacts[0].normal);
			
			if (Mathf.Abs(other.contacts[0].normal.x) == 1)
			{
				newVelocity = new Vector2(-newVelocity.x, newVelocity.y);
			}else if (Mathf.Abs(other.contacts[0].normal.y) == 1)
			{
				newVelocity = new Vector2(newVelocity.x, -newVelocity.y);
			}
			
			rb.velocity = newVelocity;
		}
	}
}
