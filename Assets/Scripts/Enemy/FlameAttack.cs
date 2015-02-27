using UnityEngine;
using System.Collections;

public class FlameAttack : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void OnParticleCollision (GameObject other) {
		if(other.name=="Astronaut")
		Debug.Log (other.name+" IS ON FIRE CAUSED BY "+this.name);
		
	}
}
