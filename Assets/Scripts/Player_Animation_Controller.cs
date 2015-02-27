using UnityEngine;
using System.Collections;
[RequireComponent(typeof(Physics_Calculator))]
public class Player_Animation_Controller : MonoBehaviour {

	//Gun Handling
	public GameObject Pistol;
	public GameObject Rifle;
	public GameObject Electro;
	public GameObject Plasma;
	
	// Player Handling
	
	private float walkSpeed = 8;
	private float runSpeed = 12;
	private float acceleration = 30;
	private float jumpHeight = 12;
	private float previous_loc = 2;
	
	// System
	
	private float animationSpeed;
	private float currentSpeed;
	private float targetSpeed;
	private Vector2 amountToMove;
	
	public Transform Suits;
	// States
	private bool jumping;
	
	private float location;
	
	// Components
	private Physics_Calculator playerPhysics;
	private Animator animator;

	void Falling(float prev_loc){
		location = transform.position.y;
		animator.SetFloat ("Location", location);
		if (previous_loc <= location) {
			animator.SetBool("Falling", false);
		}
		if (previous_loc >location) {
			animator.SetBool("Falling", true);
		}
	}
	
	void Crouch(){
		if (Input.GetKeyDown ("c")) {
			animator.SetBool ("Crouch",true);
			Vector3 suits = Suits.localPosition;
			Debug.Log (suits);
			suits.y = -0.5775575f;
			Suits.localPosition = suits;


		}
		if (Input.GetKeyUp ("c")){
			animator.SetBool ("Crouch",false);
			Vector3 suits = Suits.localPosition;
			suits.y = -0.72f;
			Suits.localPosition = suits;
		}
	}
	

	void Shoot(){
		
		if (Input.GetMouseButtonDown (0)) {
			animator.SetBool("Fire",true);
		}
		if (Input.GetMouseButtonUp (0)) {
			animator.SetBool("Fire",false);
		}
	}
	
	void TypeGun(){
		
		if(Pistol.activeSelf){
			animator.SetBool("Pistol",true);
			animator.SetBool ("SMG", false);
			animator.SetBool ("LMG", false);
			animator.SetBool("Electro",false);
		}
		if (Rifle.activeSelf){
			animator.SetBool ("SMG", true);
			animator.SetBool ("Pistol", false);
			animator.SetBool ("LMG", false);
			animator.SetBool("Electro",false);
		}
		if (Plasma.activeSelf){
			animator.SetBool ("LMG", true);
			animator.SetBool ("SMG", false);
			animator.SetBool ("Pistol", false);
			animator.SetBool("Electro",false);
		}
		if(Electro.activeSelf){
			animator.SetBool("Electro",true);
			animator.SetBool ("SMG", false);
			animator.SetBool ("LMG", false);
			animator.SetBool("Pistol",false);
		}
		
	}
	
	void Start () {
		previous_loc = transform.position.y;
		playerPhysics = GetComponent<Physics_Calculator>();
		animator = GetComponentInChildren<Animator>();


		
	}
	
	
	
	void Update () {

		float movedir = Input.GetAxisRaw("Horizontal");
		
		
		//ClimbUP (movedir);
		//ClimbDOWN (movedir);
		Falling (previous_loc);
		Crouch ();

		Shoot ();
		TypeGun ();
		
		previous_loc = location;
		// Reset acceleration upon collision
		if (playerPhysics.movementStopped) {
			targetSpeed = 0;
			currentSpeed = 0;
		}
		// Jump Input
		if (Input.GetButtonDown("Jump")) {
			amountToMove.y = jumpHeight;
			jumping = true;
			animator.SetBool("Jumping",true);
		}
		else{
			animator.SetBool ("Jumping",false);
		}
		// If player is touching the ground
		if (playerPhysics.grounded) {
			amountToMove.y = 0;
		}
		
		
		
		
		// Set animator parameters
		animationSpeed = IncrementTowards(animationSpeed,Mathf.Abs(targetSpeed),acceleration);
		animator.SetFloat("Speed",animationSpeed);
		
		if (animationSpeed > 8) {
			animator.SetBool ("Crouch",false);
		}
		
		// Input
		
		float speed = (Input.GetButton("Run"))?runSpeed:walkSpeed;
		targetSpeed = Input.GetAxisRaw("Horizontal") * speed;
		currentSpeed = IncrementTowards(currentSpeed, targetSpeed,acceleration);
		
		// Face Direction
		float moveDir = Input.GetAxisRaw("Horizontal");
		if (moveDir >0) {
			transform.eulerAngles = (moveDir>0)?Vector3.up * 90:Vector3.zero;
			
		}
		if (moveDir <0) {
			transform.eulerAngles = (moveDir<0)?Vector3.up * 270:Vector3.zero;
			
		}
		

	}
	
	
	
	
	// Increase n towards target by speed
	private float IncrementTowards(float n, float target, float a) {
		if (n == target) {
			return n;	
		}
		else {
			float dir = Mathf.Sign(target - n); // must n be increased or decreased to get closer to target
			n += a * Time.deltaTime * dir;
			return (dir == Mathf.Sign(target-n))? n: target; // if n has now passed target then return target, otherwise return n
		}
	}

}
