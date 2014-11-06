using UnityEngine;
using System.Collections;

[RequireComponent(typeof(PlayerPhysics))]
public class PlayerController : MonoBehaviour {
	
	// Player Handling
	public float gravity = 20;
	public float walkSpeed = 8;
	public float runSpeed = 12;
	public float acceleration = 30;
	public float jumpHeight = 12;
	public float slideDeceleration = 10;
	public float previous_loc = 2;
	public float climbSpeed = 15;

	//Stats
	private int oriMaxHP = 100;
	private int curHP = 100;
	private int curMAXHP = 100;

	private int oriMaxOXY = 100;
	private int curOXY = 100;
	private int curMAXOXY = 100;

	private int oriMaxMat = 100;
	private int curMat = 100;
	private int curMAXMat = 100;

	private int oriMaxFuel = 100;
	private int curFuel = 100;
	private int curMAXFuel = 100;

	// System

	private float animationSpeed;
	private float currentSpeed;
	private float targetSpeed;
	private Vector2 amountToMove;
	
	// States
	private bool jumping;
	private bool sliding;

	private float location;

	// Components
	private PlayerPhysics playerPhysics;
	private Animator animator;
	
	void ClimbUP(float movedir){
		if (Input.GetKeyDown ("w")) {
			transform.eulerAngles = (movedir==0)?Vector3.up * 360:Vector3.zero;
			if (Input.GetKeyDown ("a") || Input.GetKeyDown ("d")){
				animator.SetBool("ClimbingUP", false);
			}
			else{
				animator.SetBool("ClimbingUP", true);
				
			}
		}
		if (Input.GetKeyUp ("w")) {
			animator.SetBool("ClimbingUP", false);

		}
	
	}
	void ClimbDOWN (float movedir){
		if (Input.GetKeyDown ("s")) {
			transform.eulerAngles = (movedir==0)?Vector3.up * 360:Vector3.zero;
			if (Input.GetKeyDown ("a") || Input.GetKeyDown ("d")){
				animator.SetBool("ClimbingDOWN", false);

			}
			else{
				animator.SetBool("ClimbingDOWN", true);		
			}
		}
		if (Input.GetKeyUp ("s")) {
			animator.SetBool("ClimbingDOWN", false);

		}
	}
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
		}
		if (Input.GetKeyUp ("c")){
			animator.SetBool ("Crouch",false);
		}
	}

	void Reload(){
		if (Input.GetKeyDown ("r")) {
			animator.SetBool ("Reload",true);
		}

		if (Input.GetKeyUp ("r")) {
			animator.SetBool ("Reload",false);
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
	void Start () {
		previous_loc = transform.position.y;
		playerPhysics = GetComponent<PlayerPhysics>();
		animator = GetComponent<Animator>();


	}
	
	void Update () {
		float movedir = Input.GetAxisRaw("Horizontal");


		ClimbUP (movedir);
		ClimbDOWN (movedir);
		Falling (previous_loc);
		Crouch ();
		Reload ();
		Shoot ();

		previous_loc = location;
		// Reset acceleration upon collision
		if (playerPhysics.movementStopped) {
			targetSpeed = 0;
			currentSpeed = 0;
		}
		
		// If player is touching the ground
		if (playerPhysics.grounded) {
			amountToMove.y = 0;
			
			// Jump logic
			if (jumping) {
				jumping = false;
				animator.SetBool("Jumping",false);
			}
			
			// Slide logic
			if (sliding) {
				if (Mathf.Abs(currentSpeed) < .25f) {
					sliding = false;
					animator.SetBool("Sliding",false);
					playerPhysics.ResetCollider();
				}
			}
			
			
			// Jump Input
			if (Input.GetButtonDown("Jump")) {
				amountToMove.y = jumpHeight;
				jumping = true;
				animator.SetBool("Jumping",true);
			}
			
			// Slide Input
			if (Input.GetButtonDown("Slide")) {
				sliding = true;
				animator.SetBool("Sliding",true);
				targetSpeed = 0;
				
				playerPhysics.SetCollider(new Vector3(10.3f,1.5f,3), new Vector3(.35f,.75f,0));
			}
		}
		
		// Set animator parameters
		animationSpeed = IncrementTowards(animationSpeed,Mathf.Abs(targetSpeed),acceleration);
		animator.SetFloat("Speed",animationSpeed);
		if (animationSpeed == 0) {
			animator.SetBool("Idle",true);
		}
		else{
			animator.SetBool("Idle",false);
		}
		if (animationSpeed > 8) {
			animator.SetBool ("Crouch",false);
		}
		
		// Input
		if (!sliding) {
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
		else {
			currentSpeed = IncrementTowards(currentSpeed, targetSpeed,slideDeceleration);
		}
		
		// Set amount to move
		amountToMove.x = currentSpeed;
		amountToMove.y -= gravity * Time.deltaTime;
		playerPhysics.Move(amountToMove * Time.deltaTime);

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
