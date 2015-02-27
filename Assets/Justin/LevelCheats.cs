using UnityEngine;
using System.Collections;

public class LevelCheats : MonoBehaviour {

	public GameObject[] locations;
	public string[] keysLoc;
	private GameObject player;

	// Use this for initialization
	void Start () {
		player = GameObject.FindWithTag ("Player");
	}
	
	// Update is called once per frame
	void Update () {
		int level = 0;
		Vector3 loc = new Vector3();
		foreach (string s in keysLoc) {
			if(Input.GetKeyDown(s)){
				loc = locations[level].transform.position;
				player.transform.position = loc;
			}	
			level++;
		}
		if (Input.GetKeyDown (KeyCode.L)) {
			Application.LoadLevel("enemyjump");		
		}
	}
}
