using UnityEngine;
using System.Collections;

public class Elevator_Control : MonoBehaviour {
	public GameObject Player;
	private Transform Astronaut;
	public  float[] positions = new float[4] ;
	public Vector3 speed = new Vector3(0,1,0);
	public float velocity = 2;

	public int counter = 1;
	private Vector3 newposition;
	private bool move = false;
	private bool reversed = false;
	private bool playerinside = false;
	// Use this for initialization
	void Start () {
		newposition = new Vector3 (this.transform.localPosition.x, this.transform.localPosition.y, this.transform.localPosition.z);
		Astronaut = Player.transform;

	}
	
	// Update is called once per frame
	void Update () {
		if(playerinside == true){
			if(Input.GetKeyDown("s")){

				if(counter -1 >-1){
					counter --;
				}
			}


			if(Input.GetKeyDown("w")){
				if(counter + 1 < positions.Length){
					counter++;
				}
			}

		}

		if (Mathf.Abs(Astronaut.position.y - transform.position.y) > 5 && move == false) {

			if (Astronaut.position.y - transform.position.y < 0 && move == false){
				if(counter -1 >-1){
					counter --;
				}

			}
			if (Astronaut.position.y - transform.position.y > 0 && move == false){
				if(counter + 1 < positions.Length - 1){
					counter++;
				}
			}
			move = true;

		}

		if (move == true) {
			newposition = new Vector3(this.transform.localPosition.x,positions[counter],this.transform.localPosition.z);
			transform.localPosition = Vector3.SmoothDamp (transform.localPosition, newposition, ref speed, velocity);
			if(Mathf.Abs(transform.localPosition.y - newposition.y) > 0 && Mathf.Abs(transform.localPosition.y - newposition.y) < .001 ){
				move = false;
			}
		}

//		Debug.Log(Mathf.Abs(transform.localPosition.y - newposition.y));

	}
	void OnTriggerStay(Collider other){

		if (other.tag == "Player") {
			move = true;
			playerinside = true;

		}
	
	}
	void OnTriggerExit(Collider other){
		if (other.tag == "Player") {
			playerinside = false;		
		}
	}
}
