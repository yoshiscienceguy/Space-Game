using UnityEngine;
using System.Collections;

public class Dragon_AI : MonoBehaviour {
	private bool attack = false;
	private bool typeattack = false;
	private Animator DragonController;
	public Animator Dragon;

	// Use this for initialization
	void Start () {
		DragonController = GetComponent<Animator> ();
		DragonController.SetBool("Melee",false);
		Dragon.SetBool("Melee",false);
		DragonController.SetBool("Barrel",false);
		Dragon.SetBool("Barrel",false);
	}
	
	// Update is called once per frame
	void Update () {

		if (attack == false) {
			int random = Random.Range (0,2);
			if(random == 1){
				DragonController.SetBool("Melee",true);
				Dragon.SetBool("Melee",true);
				DragonController.SetBool("Barrel",false);
				Dragon.SetBool("Barrel",false);
			}
			else{
				DragonController.SetBool("Melee",false);
				Dragon.SetBool("Melee",false);
				DragonController.SetBool("Barrel",true);
				Dragon.SetBool("Barrel",true);
			}
			attack = true;
			StartCoroutine(AnimationWait());
		}
	}
	IEnumerator AnimationWait(){
		yield return new WaitForSeconds(2);
		DragonController.SetBool("Melee",false);
		Dragon.SetBool("Melee",false);
		DragonController.SetBool("Barrel",false);
		Dragon.SetBool("Barrel",false);
		yield return new WaitForSeconds(10);
		attack = false;

	}
	void OnTriggerEnter(Collider other){
		if (other.tag == "Player") {
			other.GetComponent<Player_Health>().Take_Damage(50);		
		}
		if (other.tag == "Bullet") {
			GetComponent<Dragon_Health>().Take_Damage(other.GetComponent<Damage_to_Player>().Damage);
			other.gameObject.SetActive(false);	
		}
	}
}
