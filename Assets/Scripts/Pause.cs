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
				//GameObject.Find("First Person Controller").GetComponent(MouseLook).enabled = false;
				showGUI = true;
			}
		}
		
		if(pauseGame == false)
		{
			Time.timeScale = 1;
			pauseGame = false;
			GameObject.Find("Player").GetComponent<MoveController>().enabled = true;
			//GameObject.Find("First Person Controller").GetComponent(MouseLook).enabled = true;
			showGUI = false;
		}
		
		if(showGUI == true)
		{
			telaPause.GetComponent<GUITexture>().enabled = true;  
		}
		
		else
		{
			telaPause.GetComponent<GUITexture>().enabled = false;  
		}
	}
}