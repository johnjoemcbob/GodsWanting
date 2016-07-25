using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {
	
	public static int noOfPlayers = 4;
	
	public GameObject player;
	public GameObject levelElements;
	
	public Vector2[] spawnPos;
	public Color[] playerColor;
	
	// public SliderGroup noOfPlayersSG;
	
	private GameObject currentLevel;
	
	// Use this for initialization
	void Start () {
		// noOfPlayersSG.SetUp(noOfPlayers, UpdateNoOfPlayers);
		StartGame();
	}
	
	public void StartGame () {
		
		// currentLevel = Instantiate(levelElements) as GameObject;
	
		for (int i = 0; i < noOfPlayers; i++)
		{
			GameObject temp = Instantiate(player, spawnPos[i], Quaternion.identity) as GameObject;
			
			temp.GetComponentInChildren<PlayerControl>().SetUp(i, playerColor[i]);
			// temp.transform.SetParent(currentLevel.transform);
		}
	}
}
