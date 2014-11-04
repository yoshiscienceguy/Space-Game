using UnityEngine;
using System.Collections;

public class box_rotating : MonoBehaviour {


	public GameObject next_box;
	
	void Update(){
		
	}
	
	void OnTriggerEnter(Collider c){
		if(c.tag == "Player")
		{
			Debug.Log ("Upgrade");
			gameObject.SetActive(false);
			next_box.SetActive(true);
			
		}
	}
}
