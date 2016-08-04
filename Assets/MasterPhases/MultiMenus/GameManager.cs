using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {
	
	public static int noOfPlayers = 4;
	public static int noOfTeams = 2;
	
	public float phase1Timer;
	
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
		StartPhase2(); // dziek remove me yeah okay good we're great fam
		
		// levelElements.SetActive(false);
	}
	
	public void StartGame () {
		
		// currentLevel = Instantiate(levelElements) as GameObject;
		levelElements.SetActive(true);
	
		for (int i = 0; i < noOfPlayers; i++)
		{
			GameObject tempPlayer = Instantiate(player, playerSpawnPositions[i], Quaternion.identity) as GameObject;
			
			
			tempPlayer.GetComponentInChildren<Player>().SetUp(i, playerColor[i], playerSpawnPositions[i]);
			// temp.transform.SetParent(currentLevel.transform);
			
			
		}
		
		for (int i = 0; i < noOfTeams; i++)
		{
			GameObject tempBoss = Instantiate(god, bossSpawnPositions[i], Quaternion.identity) as GameObject;

			// Initialise leg joysticks
			int player = 0;
			foreach ( JoystickControlLegScript joystick in tempBoss.GetComponentsInChildren<JoystickControlLegScript>() )
			{
				joystick.CameraParent = phase2Elements;
				joystick.Joystick_Horizontal = "Stick_H_" + ( i * 2 + player );
				joystick.Joystick_Vertical = "Stick_V_" + ( i * 2 + player );
				player++;
			}

			// Initialise walk buttons
			player = 0;
			foreach ( InputActivatorScript input in tempBoss.GetComponentsInChildren<InputActivatorScript>() )
			{
				input.Button = "Shoulder_1_" + ( i * 2 + player );
				player++;
			}

			// Initialise crouch axes
			CrouchJumpScript crouch = tempBoss.transform.GetChild( 0 ).GetComponent<CrouchJumpScript>();
			crouch.CrouchButton_Player1 = "Shoulder_2_" + ( i * 2 + 0 );
			crouch.CrouchButton_Player2 = "Shoulder_2_" + ( i * 2 + 1 );
		}
		
		StartCoroutine("Timer");
	}
	
	public void StartPhase2 () {
		phase2Elements.SetActive( true );
		phase2Elements.GetComponent<KeyframeAnimationHandlerScript>().OnActivate();
	}
	
	public void TheEnd () {
		
	}
	
	IEnumerator Timer () {
		float t = 0;
		
		while (t < phase1Timer)
		{
			t += Time.deltaTime;
			yield return null;
		}
	}
}
