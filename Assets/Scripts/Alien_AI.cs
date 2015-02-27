using UnityEngine;
using System.Collections;

public class Alien_AI : MonoBehaviour {

	public GameObject Astronaut;
	public float follow_speed = 1;
	public float range_aiming = 5;


	private bool follow = false;
	private float moveDir;
	private Vector3 direction;
	private Vector3 original_position;
	private Animator animator;
	private Vector3 newposition;


	void Face(){
		if(moveDir > 0){
			transform.eulerAngles = (moveDir>0)?Vector3.up * 90:Vector3.zero;
		}
		if(moveDir < 0){
			transform.eulerAngles = (moveDir<0)?Vector3.up * 270:Vector3.zero;
		}
	}
	void Start () {

		original_position = transform.position;
		animator = GetComponentInChildren<Animator>();

	}
	
	// Update is called once per frame
	void Update () {
		//Debug.Log ("X: "+ moveDir)
		if (follow == true) {
			animator.SetBool("Walk",false);
			moveDir = Astronaut.transform.position.x - this.transform.position.x;
			Face ();


			if(Vector3.Distance(transform.position, Astronaut.transform.position) > range_aiming){
				animator.SetBool ("Ready",false);
				animator.SetBool("Shoot",false);
				animator.SetBool("Moving",true);
				animator.SetBool("Push",false);
				transform.position = Vector3.Lerp (transform.position, newposition, Time.deltaTime * follow_speed); 

			}
			else{
				 
				animator.SetBool ("Moving",false);
				animator.SetBool ("Ready",true);
				animator.SetBool ("Shoot",true);

			}
		}
		else 
		{

			moveDir = original_position.x - this.transform.position.x;
			animator.SetBool("Push",false);
			if(Vector3.Distance(transform.position, original_position) > 1){
				Face ();
				animator.SetBool("Shoot",false);
				animator.SetBool ("Ready",false);
				animator.SetBool("Walk",true);
				animator.SetBool("Moving",true);

				transform.position = Vector3.MoveTowards(transform.position, original_position, Time.deltaTime * 5); 	
			}
			else{
				animator.SetBool("Shoot",false);
				animator.SetBool ("Ready",false);
				animator.SetBool ("Moving",false);
				animator.SetBool("Walk",false);

			}
		}

		
		//if(Vector3.Distance(transform.position, objective.position) < sensitivity){
	}

	void OnTriggerEnter(Collider other){

		if (other.gameObject.tag == "Player") {
			newposition = new Vector3 (Astronaut.transform.position.x, this.transform.position.y, this.transform.position.z);
			follow = true;

		}

	}
	void OnTriggerStay(Collider other){
		if (other.gameObject.tag == "Player") {
			newposition = new Vector3 (Astronaut.transform.position.x, this.transform.position.y, this.transform.position.z);
			follow = true;
			
		}
		
	}
	void OnTriggerExit(Collider other){
		if (other.gameObject.tag == "Player") {
			follow = false;

		}
	}

}
