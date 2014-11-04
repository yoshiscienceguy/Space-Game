using UnityEngine;
using System.Collections;

public class Death : MonoBehaviour {
	
	// Use this for initialization
	private Vector3 position;
	private Animator animator;

	void Start() {
		position.x = 0;
		position.y = 10;
		position.z = 0;
		}
	// Update is called once per frame
	void Update () {
	
			
			if(transform.position.y < - 10)
			{
				transform.position = position;
				animator.SetBool("Falling",false);
				
			}

	}
}
