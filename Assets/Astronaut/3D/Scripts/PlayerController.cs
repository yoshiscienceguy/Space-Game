using UnityEngine;
using System.Collections;

[RequireComponent(typeof(PlayerPhysics))]
public class PlayerController : MonoBehaviour {
	
	// Player Handling

	private float walkSpeed = 8;
	private float runSpeed = 12;
	private float acceleration = 30;
	private float jumpHeight = 12;
	private float slideDeceleration = 10;
	private float previous_loc = 2;
	private float climbSpeed = 15;
	
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
	
	//bullets
	public  Rigidbody  Bullet;
	
	// States
	private bool jumping;
	private bool sliding;
	private bool fired;
	
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
			Debug.Log("FIRING"+gameObject.GetComponent<BoxCollider>().size.y);
			animator.SetBool("Fire",true);
			
			//Vector3 direction = Camera.main.ScreenToWorldPoint ( new Vector3 ( Input.mousePosition.x, Input.mousePosition.y, 1000 ) );
			//direction = direction-transform.position;
			//Debug.DrawLine (transform.position, direction);
			//direction.Normalize();
			//Debug.Log("DIRECTION : "+direction);
			
			
			//	RaycastHit hit ;
			//	var ray = Camera.main.ScreenPointToRay (Input.mousePosition);
			//			Physics.Raycast (ray, hit, 100);
			float a = gameObject.GetComponent<BoxCollider>().size.y/4;
			Debug.Log(transform.position+"---"+a+":"+(transform.position.y+a));
			//Vector3 firingPos = new Vector3( transform.position.x, transform.position.y+a , 0);
			var projectile = Instantiate(Bullet, transform.position, Quaternion.identity) as Rigidbody;
			
			curMat--;
			//var projectile = Instantiate(Bullet, transform.position, Quaternion.Euler(new Vector4(0,0,0,Mathf.Atan2 ( direction.y, direction.x ) * Mathf.Rad2Deg ))) as Rigidbody;
			//projectile.velocity = direction * 5f;
			// turn the projectile to hit.point
			//	projectile.transform.LookAt(hit.point);
			// accelerate it
			//projectile.rigidbody.AddForce(transform.forward* 1000000f,ForceMode.Impulse);
			//Debug.Log(transform.forward);
			DestroyObject(projectile.gameObject,3f);
			//Destroy(projectile as GameObject,3f);
			Debug.Log("FIRING WHY NO?");
			//			float XvelocityVector =(Camera.main.ScreenToWorldPoint(Input.mousePosition).x) - (transform.position.x);
			//			float YvelocityVector = (Camera.main.ScreenToWorldPoint(Input.mousePosition).y) - (transform.position.y);
			//			Vector2 direction = new Vector2(XvelocityVector,YvelocityVector);
			//			direction.Normalize();
			//			Rigidbody  instanceBullet = Instantiate
			//					(Bullet,
			//				 transform.position, Quaternion.identity) as  Rigidbody ;
			//			instanceBullet.rigidbody.AddForce(transform.forward *
			//			                                  2f);
		}
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
	
	public void GetLoot(string loot){
		Debug.Log ("CURLOOT : "+curMat + ";;;"+curFuel);
		Debug.Log ("GETLOOT : "+loot);
		string[] s = loot.Split (';');
		foreach (string l in s) {
			string [] tmp = l.Split(':');
			if (tmp[0] == "0") {
				Debug.Log("ADD TO MAT");
				curMat +=int.Parse(tmp[1]);		
			}else if (tmp[0] == "1") {
				Debug.Log("ADD TO FUEL");
				curFuel +=int.Parse(tmp[1]);				
			}
		}
		Debug.Log ("CURLOOT : "+curMat + ";;;"+curFuel);
	}
	
	public void Hurt(int damage){
		Debug.Log ("IMMA GETTING DAMAGES "+damage);
		curHP -= damage;
		Debug.Log ("MY HP IS AT "+curHP);
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

			
			// Slide logic
			if (sliding) {
				if (Mathf.Abs(currentSpeed) < .25f) {
					sliding = false;
					animator.SetBool("Sliding",false);
					playerPhysics.ResetCollider();
				}
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
