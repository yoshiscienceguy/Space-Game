using UnityEngine;
using System.Collections;

public class Mover : MonoBehaviour {

	public GameObject Player;
	private float original;
	private Animator animator;

	void Start(){
		original = Player.GetComponent<ThirdPersonController>().gravity;
		animator = Player.GetComponentInChildren<Animator>(); 	
	}
	
	void OnTriggerEnter(Collider other ){
		if(other.tag == "Player"){

			Player.GetComponent<ThirdPersonController>().gravity = 1;
			Player.GetComponent<ThirdPersonController>().canJump = false;

			animator.SetBool("Jumping",false);
			animator.SetBool("Falling",true);
			animator.SetBool("Crouch",false);
			Player.gameObject.transform.parent = gameObject.transform;
			
		}
	}
	void  OnTriggerStay(Collider other ){
		if(other.tag == "Player"){
			
			animator.SetBool("Jumping",false);
			animator.SetBool("Falling",false);
			animator.SetBool("Crouch",false);
			
		}
	}
	
	void  OnTriggerExit(Collider other){
		if (other.tag == "Player") {
			Player.GetComponent<ThirdPersonController>().gravity = original;
			Player.GetComponent<ThirdPersonController>().canJump = true;
			Player.gameObject.transform.parent = null;	
		}
	}

}
