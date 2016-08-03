using UnityEngine;
using System.Collections;

public class CanvasManager : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	public void LoadMenu (GameObject menu) {
		menu.SetActive(true);
	}
	
	public void HideMenu (GameObject menu) {
		menu.SetActive(false);
	}
}
