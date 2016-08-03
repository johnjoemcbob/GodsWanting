﻿using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {
	
	public static int noOfPlayers = 4;
	public static int noOfTeams = 2;
	
	public GameObject player;
	public GameObject god;
	
	public GameObject levelElements;
	public GameObject phase1Elements;
	public GameObject phase2Elements;
	
	public Transform playerSpawnObject;
	public Transform bossSpawnObject;
	
	// public Vector2[] spawnPos;
	public Color[] playerColor;
	
	private Vector3[] playerSpawnPositions;
	private Vector3[] bossSpawnPositions;
	
	// public SliderGroup noOfPlayersSG;
	
	private GameObject currentLevel;
	
	void Awake () {
		playerSpawnPositions = new Vector3[playerSpawnObject.childCount];
		bossSpawnPositions = new Vector3[bossSpawnObject.childCount];
		
		for (int i = 0; i < playerSpawnPositions.Length; i++) 
		{
			playerSpawnPositions[i] = playerSpawnObject.GetChild(i).position;
		}
		
		for (int i = 0; i < bossSpawnPositions.Length; i++) 
		{
			bossSpawnPositions[i] = bossSpawnObject.GetChild(i).position;
		}
	}
	
	// Use this for initialization
	void Start () {
		// noOfPlayersSG.SetUp(noOfPlayers, UpdateNoOfPlayers);
		StartGame();
		
		// levelElements.SetActive(false);
	}
	
	public void StartGame () {
		
		// currentLevel = Instantiate(levelElements) as GameObject;
		levelElements.SetActive(true);
	
		for (int i = 0; i < noOfPlayers; i++)
		{
			GameObject tempPlayer = Instantiate(player, playerSpawnPositions[i], Quaternion.identity) as GameObject;
			
			
			tempPlayer.GetComponentInChildren<Player>().SetUp(i, playerColor[i]);
			// temp.transform.SetParent(currentLevel.transform);
			
			
		}
		
		for (int i = 0; i < noOfTeams; i++)
		{
			GameObject tempBoss = Instantiate(god, bossSpawnPositions[i], Quaternion.identity) as GameObject;
		}
	}
	
	public void StartPhase2 () {
		
	}
	
	public void TheEnd () {
		
	}
}