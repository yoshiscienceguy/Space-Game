using UnityEngine;
using System.Collections;

public class One_Time_Explosion : MonoBehaviour {
	void Start(){
		GetComponentInParent<Rockets> ().enabled = false;
	}
	void OnTriggerEnter(){
		GetComponentInParent<Rockets> ().enabled = true;
	}
}
