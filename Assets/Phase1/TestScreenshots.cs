using UnityEngine;
using System.Collections;

public class TestScreenshots : MonoBehaviour {
	
	private int sNum = 0;
	private string sFolder = "Promotional/InGame/";
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown("f9") || Input.GetButtonDown("Dash_0"))
		{
			string screenshotFilename = sFolder + "Screenshot" + sNum + ".png";
            // do
            // {
                // sNum++;
                // screenshotFilename = "screenshot" + sNum + ".png";
 
            // } 
			
			while (System.IO.File.Exists(screenshotFilename))
			{
				sNum++;
                screenshotFilename = sFolder + "Screenshot" + sNum + ".png";
			}
		
			Application.CaptureScreenshot(screenshotFilename, 1);
			Debug.Log("Screenshot " + sNum + " Captured!");
			// sNum++;
			// PlayerPrefs.SetInt("ScreenshotNumber", sNum);
		}
	}
}
