using UnityEngine;
using System.Collections;

public class Elevator_Trigger_Down : MonoBehaviour {
	public Animator animator;
	// Use this for initialization
	void Start () {
		animator = GetComponentInParent<Animator>();
	}
	
	// Update is called once per frame
	void OnTriggerEnter(Collider other){
		animator.SetBool ("Down", true);
	}

	void OnTriggerExit(Collider other){
		animator.SetBool ("Down", false);
	}
}
