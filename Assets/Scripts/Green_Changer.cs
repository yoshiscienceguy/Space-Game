using UnityEngine;
using System.Collections;

public class Green_Changer : MonoBehaviour {

	public GameObject Suits;
	public GameObject Green_Suit;
	public GameObject Guns;
	public GameObject Player;

	// Use this for initialization
	void OnTriggerEnter(Collider collider){
		
		for (int i = 0; i<Suits.transform.childCount; i++) {
			GameObject child = Suits.transform.GetChild(i).gameObject;
			child.SetActive(false);
		}
		
		Green_Suit.SetActive (true);
		Guns.SetActive (true);
		gameObject.SetActive (false);

		Player.GetComponent<Player_Health> ().Armor = 100f;
	}
}
