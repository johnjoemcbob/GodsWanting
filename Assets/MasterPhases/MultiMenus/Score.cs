using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Score : MonoBehaviour {
	
	public static int scoreNeeded = 5;
	
	public int score = 0;
	
	public SliderGroup scoreNeededSG;
	
	// Use this for initialization
	void Start () {
		scoreNeededSG.SetUp(scoreNeeded, UpdateScoreNeeded);	
	}
	
	public void ChangeScore (int c) {
		score = Mathf.Clamp(score+c, -scoreNeeded, scoreNeeded);
	}
	
	void UpdateScoreNeeded (float v) {
		scoreNeeded = (int)v;
	}
}
