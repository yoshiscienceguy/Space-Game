using UnityEngine;
using System.Collections;

public class Dragon_Trigger_lvl2 : MonoBehaviour {
	public Animator Dragon_Controller;
	public Animator Dragon_Animator;
	// Use this for initialization

	void OnTriggerEnter(Collider other){
		if (other.tag == "Player") {
			Dragon_Controller.SetBool("Fly",true);
			Dragon_Animator.SetBool("Fly",true);
		}
	}
}
