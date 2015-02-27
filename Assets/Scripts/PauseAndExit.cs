using UnityEngine;
using System.Collections;

public class PauseAndExit : MonoBehaviour {

	public bool isPaused;
	GUIStyle style;

	// Use this for initialization

	void OnAwake(){
		isPaused = false;
		}

	void Start () {
		isPaused = false;

	}
	
	// Update is called once per frame
	void Update () {
			if (Input.GetKey(KeyCode.Escape)) {
			isPaused = true;;
					if(isPaused){
						Time.timeScale =0.0f;
						
					}					
				}
	}

	void OnGUI(){
		style = new GUIStyle(GUI.skin.label);;
		style.fontSize = 80;
			if(isPaused) {
			GUI.Label(new Rect ((Screen.width/2) - 175, Screen.height - ((Screen.height/2) +  200 ), 600, 100), "Paused", style);
			GUI.Box(new Rect(0, 0, Screen.width, Screen.height), " ");
			if(GUI.Button(new Rect( Screen.width/2 - 125, Screen.height - ((Screen.height/2 +50)), 200, 100), "Unpause")){
				isPaused = false;
				Time.timeScale = 1.0f;
				}
			if(GUI.Button(new Rect( Screen.width/2 - 125, Screen.height - ((Screen.height/2 -50)), 200, 100), "Exit")){
				isPaused = false;
				Time.timeScale = 1.0f;
				Application.LoadLevel(0);

				}
			}
	
			
		}
}
