﻿using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {
	
	private int playerNum = 0;
	private Color playerColor;
	
	public void SetUp (int pN, Color c)
	{
		playerNum = pN;
		playerColor = c;
		
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
}
