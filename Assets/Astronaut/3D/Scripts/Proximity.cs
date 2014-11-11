using UnityEngine;
using System.Collections;

public class Proximity : MonoBehaviour {

	public Transform objective;
	private Animator animator;
	public int sensitivity = 5;
	// Update is called once per frame
	void Start(){
		animator = GetComponent<Animator>();
	}
	// Update is called once per frame
	void Update () {
		if(Vector3.Distance(transform.position, objective.position) < sensitivity){
			animator.SetBool("Play",true);
		}
		else {
			animator.SetBool ("Play",false);
				}
	}
}
