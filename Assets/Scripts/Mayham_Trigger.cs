using UnityEngine;
using System.Collections;

public class Mayham_Trigger : MonoBehaviour {
	public GameObject[] Turrents;
	public GameObject Battle_Cruiser;
	public GameObject[] RocketLaunchers;
	public GameObject[] Explosions;
	private bool on = false;
	private bool onetime = false;

	// Use this for initialization
	void Start () {
		foreach (GameObject turrent in Turrents) {
			turrent.GetComponent<Sentry_Detection>().enabled = false;

		}
		foreach (GameObject rocket in RocketLaunchers) {
			rocket.GetComponentInChildren<Rocket_launcher>().enabled = false;
			
		}

		foreach (GameObject explosion in Explosions) {
			explosion.GetComponent<Rockets>().enabled = false;

		}
		Battle_Cruiser.GetComponent<Animator>().enabled = false;
		Battle_Cruiser.GetComponent<BattleCruiser_Follow> ().enabled = false;

	}
	
	// Update is called once per frame
	void Update () {
		if (onetime == true && on == true) {
			foreach (GameObject turrent in Turrents) {
				turrent.GetComponent<Sentry_Detection>().enabled = true;
				
			}
			foreach (GameObject rocket in RocketLaunchers) {
				rocket.GetComponentInChildren<Rocket_launcher>().enabled = true;
				
			}
			
			foreach (GameObject explosion in Explosions) {
				explosion.GetComponent<Rockets>().enabled = true;
				
			}
			Battle_Cruiser.GetComponent<Animator>().enabled = true;
			Battle_Cruiser.GetComponent<BattleCruiser_Follow> ().enabled = true;
			on = false;
		}
	}
	void OnTriggerEnter(Collider other){
		if (other.tag == "Player") {
			on = true;	
			onetime = true;
		}
	}
}
