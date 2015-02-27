using UnityEngine;
using System.Collections;

public class Trash_Damage : MonoBehaviour {

	public float TrashDamage = 20;
	// Use this for initialization
	void OnTriggerEnter(Collider other){
		if (other.tag == "Player") {
			other.GetComponent<Player_Health>().Take_Damage(TrashDamage);		
		}
	}
}
