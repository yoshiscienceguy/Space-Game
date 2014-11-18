using UnityEngine;
using System.Collections;

public class Yellow_Changer : MonoBehaviour {

	public GameObject Suits;
	public GameObject Yellow_Suit;
	public GameObject Guns;

	// Use this for initialization
	void OnTriggerEnter(Collider collider){
		
		for (int i = 0; i<Suits.transform.childCount; i++) {
			GameObject child = Suits.transform.GetChild(i).gameObject;
			child.SetActive(false);
		}

		Yellow_Suit.SetActive (true);
		Guns.SetActive (true);
		gameObject.SetActive (false);
	}
}
