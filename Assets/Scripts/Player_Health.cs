using UnityEngine;
using System.Collections;

public class Player_Health : MonoBehaviour {

	public float Health = 100;
	public float Armor = 100;

	public GameObject healthBar;
	public float healthbarsize;

	public GameObject armorBar;
	public float armorBarSize;

	public GameObject Suits;
	public GameObject Guns;
	public GameObject JetPack;

	private Animator animator;
	// Use this for initialization
	public void Take_Damage(float damage){
		if (Health > 0) {
			if(Armor > 0){
				if(Armor - damage > 0){
					Damage_Armor(damage);
					damage = 0;

				}
				else{
					damage = damage - Armor;
					Armor = 0;

				}
				armorBar.transform.localScale = new Vector3 (armorBarSize * (Armor / 100f), armorBar.transform.localScale.y, 0f);
			}
			if(Health - damage < 0){
				Health = 0;
			}
			else{
				Health -= damage;	
			}
			healthBar.transform.localScale = new Vector3 (healthbarsize * (Health / 100f), healthBar.transform.localScale.y, 0f);
		}
		 

	}

	public void Damage_Armor(float damage){
		if (Armor > 0) {
			Armor -= damage;
			armorBar.transform.localScale = new Vector3 (armorBarSize * (Armor / 100f), armorBar.transform.localScale.y, 0f);
		}
	}
	void Start(){
		animator = GetComponentInChildren<Animator>();
		healthbarsize = healthBar.transform.localScale.x;
		armorBarSize = armorBar.transform.localScale.x;
	}
	// Update is called once per frame
	void Update () {
//		Debug.Log (Health);
		if(Health <= 0)
		{
			animator.SetBool("Death",true);
			StartCoroutine(DeathAnimation());
			//Play Death Something
		}
		if (Armor <= 0) {
			bool same = false;
			for (int i = 0; i<Suits.transform.childCount; i++) {
				GameObject child = Suits.transform.GetChild(i).gameObject;
				if(child.name =="No_Suit1"){
					if(child.activeSelf == true){
						same = true;
						break;
					}
				}
			}
			if(same == false){
				for (int i = 0; i<Suits.transform.childCount; i++) {
						GameObject child = Suits.transform.GetChild(i).gameObject;
					if(child.name != "mixamorig:Hips"){
						child.SetActive(false);
					}
					if(child.name == "No_Suit1" ){
						JetPack.SetActive(false);
						child.SetActive(true);
						child.GetComponent<Suit_Attributes>().Starter();

					}


				}
			
				Guns.gameObject.SetActive (true);
			}

		}
		armorBar.transform.localScale = new Vector3 (armorBarSize * (Armor / 100f), armorBar.transform.localScale.y, 0f);
	}

	void OnTriggerEnter(Collider other){

		if (other.tag == "EnemyBullet") {
			Debug.Log("hit");
			float damage = other.GetComponent<Damage_to_Player>().Damage;
			Take_Damage(damage);
			other.gameObject.SetActive(false);
		}
	}
	IEnumerator DeathAnimation(){
		
		yield return new WaitForSeconds(2);
		Application.LoadLevel(Application.loadedLevel);
		
	}

}
