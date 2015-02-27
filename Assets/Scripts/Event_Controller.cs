using UnityEngine;
using System.Collections;

public class Event_Controller : MonoBehaviour {
	public GameObject Elevator;
	public Light[] On;
	public Light[] Off;
	public float Sleep = 0;
	// Use this for initialization
	void Start () {

		Elevator.GetComponent<Elevator_Control> ().enabled =false;
		Elevator.GetComponent<Mover> ().enabled =false;
		foreach (Light lighton in On) {
			lighton.enabled = false;
		}
		foreach (Light lightoff in Off) {
			lightoff.enabled = true;
		}

	}
	


	void OnTriggerEnter(Collider other){
		if(other.tag == "Player"){
			StartCoroutine(AnimationWait());


		}
	}
	
	IEnumerator AnimationWait(){
		yield return new WaitForSeconds(Sleep);
		Elevator.GetComponent<Elevator_Control> ().enabled =true;
		Elevator.GetComponent<Mover> ().enabled = true;
		foreach (Light lighton in On) {
			lighton.enabled = true;
		}
		foreach (Light lightoff in Off) {
			lightoff.enabled = false;
		}

	}
		
}
