using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class GameManager : MonoBehaviour {
	
	public static int noOfPlayers = 4;
	public static int noOfTeams = 2;
	
	public float phase1Timer;
	
	public Slider timerSlider;
	public GameObject gameOverScreen;
	public Text gameOverText;
	
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
	private List<GameObject> Gods = new List<GameObject>();
	
	private GameObject[] players;
	
	// public SliderGroup noOfPlayersSG;
	
	private GameObject currentLevel;

	private float Phase2Started = -1;

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
		
		players = new GameObject[noOfPlayers];
	}
	
	// Use this for initialization
	void Start () {
		// noOfPlayersSG.SetUp(noOfPlayers, UpdateNoOfPlayers);
		// StartGame();
		// StartPhase2(); // dziek remove me yeah okay good we're great fam
		
		// levelElements.SetActive(false);
	}

	void Update()
	{
		if ( phase2Elements.active && ( ( Time.time - Phase2Started ) > 9 ) )
		{
			// Activate input on gods
			foreach ( GameObject god in Gods )
			{
				// Move
				foreach ( InputActivatorScript script in god.GetComponents<InputActivatorScript>() )
				{
					script.enabled = true;
				}
				// Crouching
				god.transform.GetChild( 0 ).gameObject.GetComponent<CrouchJumpScript>().enabled = true;
			}
		}
	}

	public void StartGame () {
		
		// currentLevel = Instantiate(levelElements) as GameObject;
		levelElements.SetActive(true);
	
		for (int i = 0; i < noOfPlayers; i++)
		{
			GameObject tempPlayer = Instantiate(player, playerSpawnPositions[i], Quaternion.identity) as GameObject;
			
			players[i] = tempPlayer;
			tempPlayer.GetComponentInChildren<Player>().SetUp(i, playerColor[i], playerSpawnPositions[i]);
			// temp.transform.SetParent(currentLevel.transform);
			
			
		}
		
		for (int i = 0; i < noOfTeams; i++)
		{
			GameObject tempBoss = Instantiate(god, bossSpawnPositions[i], Quaternion.identity) as GameObject;
			Gods.Add( tempBoss );
			// tempBoss.GetComponent<SetUp(noO);
			
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

			// Initialise ref to other god
			if ( i != 0 )
			{
				tempBoss.GetComponentsInChildren<Body>()[0].otherGod = Gods[0];
				Gods[0].GetComponentsInChildren<Body>()[0].otherGod = tempBoss;
			}

			// Initialise canvas keyframe
			EnableAtKeyframeScript keyframe = tempBoss.GetComponent<EnableAtKeyframeScript>();
			keyframe.KeyframeAnimation = phase2Elements.GetComponent<KeyframeAnimationHandlerScript>();
			keyframe.ActivateTime = 3;
			keyframe.DeactivateTime = 5;
			if ( i != 0 )
			{
				keyframe.ActivateTime = 6;
				keyframe.DeactivateTime = 8;
			}

			// Initialise eye keyframe
			foreach ( var eye in tempBoss.transform.GetChild( 0 ).GetChild( 0 ).GetChild( 0 ).GetChild( 0 ).GetComponentsInChildren<EyeShouldSpawnScript>() )
			{
				tempBoss.GetComponent<ActivateGroupScript>().Activatables.Add( eye );
			}
		}
		
		StartCoroutine("Timer");
	}
	
	public void StartPhase2 () {
		phase1Elements.SetActive( false );
		for (int i = 0; i < players.Length; i++)
		{
			players[i].SetActive(false);
		}
		
		phase2Elements.SetActive( true );
		phase2Elements.GetComponent<KeyframeAnimationHandlerScript>().OnActivate();
		Phase2Started = Time.time;
	}
	
	public void TheEnd (string t) {
		gameOverScreen.SetActive(true);
		gameOverText.text = "The Magnificent " + t + " Has Been Defeated"; 
	}
	
	IEnumerator Timer () {
		float t = 0;
		
		while (t < phase1Timer)
		{
			timerSlider.value = t / phase1Timer;
			t += Time.deltaTime;
			yield return null;
		}
		
		StartPhase2();
	}
}
