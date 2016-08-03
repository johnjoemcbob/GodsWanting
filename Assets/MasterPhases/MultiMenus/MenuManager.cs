using UnityEngine;
using System.Collections;

public class MenuManager : MonoBehaviour {
	
	public GameObject main;
	public GameObject gameOver;
	
	// Use this for initialization
	void Awake () {
		// main = GameObject.Find("Menu");;
	
		Messenger.AddListener("MainMenu", Main);
		Messenger.AddListener("GameOver", GameOver);
	}
	
	void OnDisable () {
		Messenger.RemoveListener("MainMenu", Main);
		Messenger.RemoveListener("GameOver", GameOver);
	}
	
	// void Update () {
		// Debug.Log(gameOver);
	// }
	
	void Main () {
		main.SetActive(true);
		// gameOver.SetActive(false);
	}
	
	void GameOver () {
		gameOver.SetActive(true);
	}
}
