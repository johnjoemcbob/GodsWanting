using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {
	
	private int playerNum = 0;
	private Color playerColor;
	
	private Vector3 playerStartSpawn;
	
	public void SetUp (int pN, Color c, Vector3 pS)
	{
		playerNum = pN;
		playerColor = c;
		playerStartSpawn = pS;
		
		// GetComponent<SpriteRenderer>().color = playerColor;
		foreach (Renderer r in GetComponentsInChildren<Renderer>())
		{
			r.material.color = playerColor;
		}
	}
	
	public int GetPlayerNum () {
		return playerNum;
	}
	
	public Color GetPlayerColor () {
		return playerColor;
	}
	
	public Vector3 GetPlayerSpawn () {
		return playerStartSpawn;
	}
}
