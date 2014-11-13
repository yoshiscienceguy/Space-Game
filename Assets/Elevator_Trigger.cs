using UnityEngine;
using System.Collections;

public class Elevator_Trigger : MonoBehaviour {
	private Animator animator;
	// Use this for initialization
	void OnTriggerEnter( Collider other){
		animator.SetBool ("Play", true);
	}


	void Start(){
		animator = GetComponent<Animator>();
	}
}
