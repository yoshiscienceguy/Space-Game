using UnityEngine;
using System.Collections;

public class Equip_Electro : MonoBehaviour {

	public GameObject Guns;
	public GameObject ElectroGun;


	// Use this for initialization
	void OnTriggerEnter(Collider collider){

		for (int i = 0; i<Guns.transform.childCount; i++) {
			GameObject child = Guns.transform.GetChild(i).gameObject;
			child.SetActive(false);
		}

		ElectroGun.SetActive (true);

		gameObject.SetActive (false);
	}
}
