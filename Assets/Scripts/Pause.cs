using UnityEngine;
using System.Collections;

public class Pause : MonoBehaviour {

	private bool pauseGame;
	private bool showGUI;

	public GUITexture telaPause;

	// Use this for initialization
	void Start () {
		pauseGame = false;
		showGUI = false;
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown(KeyCode.Escape))
		{
			pauseGame = !pauseGame;
			
			if(pauseGame == true)
			{
				Time.timeScale = 0;
				pauseGame = true;
				GameObject.Find("Player").GetComponent<MoveController>().enabled = false;
				showGUI = true;
			}
		}

		if(pauseGame == false)
		{
			Time.timeScale = 1;
			pauseGame = false;
			GameObject.Find("Player").GetComponent<MoveController>().enabled = true;
			showGUI = false;
		}

		if(showGUI == true)
		{
			telaPause.GetComponent<GUITexture>().enabled = true;
			telaPause.GetComponent<GUITexture>().pixelInset = new Rect(Screen.width/2 - telaPause.GetComponent<GUITexture>().pixelInset.width/2,Screen.height/2 - telaPause.GetComponent<GUITexture>().pixelInset.height/2, -50, -50);
		}
		else
		{
			telaPause.GetComponent<GUITexture>().enabled = false;
		}
	}
}