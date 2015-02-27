using UnityEngine;
using System.Collections;

public class Gun : MonoBehaviour
{

	public Rigidbody bullet;
	public Transform barrelexit;
	public GameObject Guns;
	public float force = 1000;
	public int ammo = 50;
	public int magazine = 8;
	public float fire_rate = .2f;
	private int originalammo;
	private int originalmag;
	public float WaitTime = 1.89f;
	public GameObject Suits;
	private Animator animator;
	private bool reloading = false;

	public bool fire = true;
//	public Transform gunarm;
//	public Transform otherarm;
	void Start(){
		originalammo = ammo;
		originalmag = magazine;
		animator = Suits.GetComponent<Animator> ();
	}
	void Update(){
		if (magazine == originalmag) {
			animator.SetBool("Reload",false);		
		}
		if(reloading == false){

			if(ammo > 0){
				if(magazine > 0){
					if(Input.GetKeyDown("r")){
						StartCoroutine(ReloadAnimation());
						reloading = true;
					}
					else if(Input.GetMouseButton(0)){
						if(fire == true){
							StartCoroutine(FireRate());
							Rigidbody bulletInstance;
							bulletInstance = Instantiate(bullet,barrelexit.position,barrelexit.rotation) as Rigidbody;
							
							bulletInstance.AddForce(barrelexit.forward * force);
							ammo--;
							
							magazine--;

							fire= false;

						}
					}
				}

				else{
					
					StartCoroutine(ReloadAnimation());
					reloading = true;
					
				}
			}
			else{
				if(gameObject.name == "Pistol_Gun"){
					ammo = originalammo;
					}
				else{
				for(int i = 0; i<Guns.transform.childCount; i++){
					GameObject child = Guns.transform.GetChild(i).gameObject;
					if(child.name != "Pistol_Gun"){
						child.SetActive(false);

					}
						else{
							child.SetActive(true);
						}
					}
				}
			}

		}



	}
	public void Reset(){
		magazine = originalmag;
		ammo = originalammo;
		fire = true;
		
	}
	IEnumerator FireRate(){
		yield return new WaitForSeconds(fire_rate);
		fire = true;
	}
	IEnumerator ReloadAnimation(){

		animator.SetBool ("Reload", true);

		Debug.Log ("Reloading");
		yield return new WaitForSeconds(WaitTime);
		Debug.Log ("done");
		animator.SetBool ("Reload", false);
		magazine = originalmag;
		reloading = false;
		fire = true;



	}


}
