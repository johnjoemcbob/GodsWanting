using UnityEngine;
using System.Collections;

public class GameStates : MonoBehaviour {

	// static MenuManager menuScript;
	
	public enum States{
		MainMenu,
		Playing,
		GameOver
	}public static States state;
	
	void Awake () {
		// menuScript = transform.GetComponent<MenuManager>();
		
		// QualitySettings.vSyncCount = 0;
	}
	
	void Start () {
		SetState("MainMenu");
		
		// Application.targetFrameRate = 60;
	}

	public void SetStateOnClick (string newState) {
		// state = (States)System.Enum.Parse(typeof(States), newState);
		// menuScript.LoadMenu(newState);
		SetState(newState);
	}
	
	public static void SetState (string newState) {
		state = (States)System.Enum.Parse(typeof(States), newState);
		Messenger.Broadcast(newState);
		// menuScript.LoadMenu(newState);
	}
	
	public static string GetState () {
		return state.ToString();
	}
}

