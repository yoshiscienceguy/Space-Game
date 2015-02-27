using UnityEngine;
using System.Collections;

public class AmmoCount : MonoBehaviour {

	public GameObject Guns;
	private GameObject gun;
	
	
	// Use this for initialization
	
	void Start () {
		
	}
	// Update is called once per frame
	void Update () {
		for (int i = 0; i<Guns.transform.childCount; i++) {
			GameObject child = Guns.transform.GetChild(i).gameObject;
			if(child.activeInHierarchy == true){
				gun = child;
			}
		}
		guiText.text = "Ammo: " + gun.GetComponent<Gun> ().ammo;
	}
	
}
