using UnityEngine;
using System.Collections;

public class Gun_Changer : MonoBehaviour {

	public GameObject Guns;
	public GameObject Gun;
	
	// Use this for initialization
	void OnTriggerEnter(Collider collider){
		if(collider.gameObject.tag == "Player"){
			for (int i = 0; i<Guns.transform.childCount; i++) {
				GameObject child = Guns.transform.GetChild(i).gameObject;
				child.SetActive(false);
			}
			
			Gun.SetActive (true);
			
			gameObject.SetActive (false);
		}
	}
}
