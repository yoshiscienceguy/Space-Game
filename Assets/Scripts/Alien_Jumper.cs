using UnityEngine;
using System.Collections;

public class Alien_Jumper : MonoBehaviour {
	public float up = 3;
	public float side = 3;
	public float speed = 2;
	private Animator animator;
	private Vector3 newpostion;
	private bool jump = false;
	private bool ready = false;
	// Use this for initialization
	void Start () {
		animator = GetComponentInChildren<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
		if (jump == false) {
				
			if(animator.GetBool("Ready") == true){

				ready = true;
			}
		}
		if(ready == true){
			newpostion = new Vector3(transform.position.x + side,transform.position.y,transform.position.z);
			ready = false;
			jump = true;
		}
		if (jump == true) {

			transform.position = Vector3.MoveTowards(transform.position,newpostion,Time.deltaTime * speed);
			if(Mathf.Abs(newpostion.x - transform.position.x) < 1){

				jump = false;
			}	

		}
	}
}
