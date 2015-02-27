using UnityEngine;
using System.Collections;

public class Openable : MonoBehaviour {
	public bool Need_Key = false;
	public string Name_Key = "Key";
	// Use this for initialization
	void Start () {
		if (Need_Key == true) {
			GetComponent<BoxCollider>().isTrigger = false;	
		}


	}

	
	void OnTriggerEnter(Collider other){
		if(Need_Key == true){
			if(other.tag == "Player"){
				if (other.GetComponent<Player_Backpack> ().If_Enabled (Name_Key) == true) {
					other.GetComponent<Player_Backpack>().Use_Object(Name_Key);
					GetComponent<BoxCollider>().isTrigger = true;
				}
			}
		}
	}
}
