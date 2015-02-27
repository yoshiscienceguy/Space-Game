using UnityEngine;
using System.Collections;

public class Up_Down_Door : MonoBehaviour {
	public float down = 12;
	public float speed = .5f;
	private Vector3 newposition;
	private float originaly;

	private bool move;
	void Start(){
		newposition = Vector3.zero;
		originaly = newposition.y;
	}
	void Update(){
		if (move == true) {
			newposition.x =0;
			newposition.z = 0;
			transform.position = Vector3.Lerp (transform.position, newposition, Time.deltaTime * speed);	
		}

	}
	void OnTriggerEnter(Collider other){
		if (other.tag == "Player") {
			newposition.y = down;
			move = true;
		}
	}
	void OnTriggerExit(Collider other){
		if (other.tag == "Player") {
			newposition.y = originaly;
			move = false;		
		}
	}
	
}
