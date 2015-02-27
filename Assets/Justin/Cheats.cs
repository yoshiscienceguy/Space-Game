using UnityEngine;
using System.Collections;

public class Cheats : MonoBehaviour {

	public GameObject Spawner;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.L)) {
			Spawner.GetComponent<Deimos> ().Spawn ();
		}
	}
}
