#pragma strict

public var Player : GameObject;
private var original : float;
private var animator : Animator;

function Start(){
	original = Player.GetComponent(ThirdPersonController).gravity;
	animator = Player.GetComponentInChildren(Animator); 	
}

function OnTriggerEnter(other : Collider ){
		if(other.tag == "Player"){
			Player.GetComponent(ThirdPersonController).gravity = 1;
			Player.GetComponent(ThirdPersonController).canJump = false;
			animator.SetBool("Jumping",false);
			animator.SetBool("Falling",true);
			animator.SetBool("Crouch",false);
			Player.gameObject.transform.parent = gameObject.transform;

		}
}
function OnTriggerStay(other : Collider ){
		if(other.tag == "Player"){

			animator.SetBool("Jumping",false);
			animator.SetBool("Falling",false);
			animator.SetBool("Crouch",false);

		}
}

function OnTriggerExit(other :Collider){
		if (other.tag == "Player") {
			Player.GetComponent(ThirdPersonController).gravity = original;
			Player.GetComponent(ThirdPersonController).canJump = true;
			Player.gameObject.transform.parent = null;	
		}
}
