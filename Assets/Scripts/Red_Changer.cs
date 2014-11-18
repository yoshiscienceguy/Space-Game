using UnityEngine;
using System.Collections;

public class Red_Changer : MonoBehaviour {

	public GameObject Suits;
	public GameObject Red_Suit;
	public GameObject Guns;
	// Use this for initialization
	void OnTriggerEnter(Collider collider){
		
		for (int i = 0; i<Suits.transform.childCount; i++) {
			GameObject child = Suits.transform.GetChild(i).gameObject;
			child.SetActive(false);
		}
		
		Red_Suit.SetActive (true);
		Guns.SetActive (true);
		gameObject.SetActive (false);
	}
}
