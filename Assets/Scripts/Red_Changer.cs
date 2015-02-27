using UnityEngine;
using System.Collections;

public class Red_Changer : MonoBehaviour {

	public GameObject Suits;
	public GameObject Suit_To_Change;

	public GameObject JetPack;

	public GameObject Player;
	public float Armor_To_Give;



	// Use this for initialization

	void OnTriggerEnter(Collider collider){

		if(collider.gameObject.tag == "Player"){
			Suit_To_Change.GetComponent<Suit_Attributes>().Starter();
			Suits.GetComponentInParent<Player_Health>().Armor = Armor_To_Give;
			for (int i = 0; i<Suits.transform.childCount; i++) {
				GameObject child = Suits.transform.GetChild(i).gameObject;
				if(child.name != "mixamorig:Hips"){
					child.SetActive(false);
				}

			}
			if (gameObject.name == "Red_PowerUp") {
				JetPack.SetActive (true);	
			}
			else{
				JetPack.SetActive(false);
			}

			Suit_To_Change.SetActive (true);

			gameObject.SetActive (false);
		}
	}

}
