using UnityEngine;
using System.Collections;

public class Alien_Health : MonoBehaviour {
	public float EnemyHealth = 100;
	public float push_distance = 5;
	public float push_speed = 2;
	public int Melee_Damage = 25;

	public GameObject HealthBar;
	public GameObject Parent;
	public GameObject Astronaut;

	public Animator astronaut_animator;
	public float boxcollider_newsize = .8f;
	public float animation_delay = .6f;
	public float starter_delay = .4f;
	private Animator animator;

	private float overallhealth;
	private float HealthSize;

	private bool waitActive = false;
	private bool push_astronaut = false;
	private bool melee = false;
	private bool inside = false;
	private bool playing = true;
	private Vector3 death_position = new Vector3(0,0,0);
	private Vector3 newposition = new Vector3(0,0,0);

	private BoxCollider boxcollider;
	private float originalsize;




	// Use this for initialization
	void Start () {
		overallhealth = EnemyHealth;
		HealthSize = HealthBar.transform.localScale.x;
		animator = Parent.GetComponentInChildren<Animator>();


		boxcollider = GetComponent<BoxCollider>();
		originalsize = boxcollider.size.x;
	}
	void Update(){

			
		

		if(melee == true){

			animator.SetBool("Push",true);
			if(push_distance > 0 ){
				astronaut_animator.SetBool("Pushed",true);
			}
			push_astronaut = true;


			if(playing == true){
				StartCoroutine(AnimationWait(animation_delay));
				playing = false;
			}
			Astronaut.transform.position = Vector3.Lerp (Astronaut.transform.position, newposition, Time.deltaTime * push_speed);

			if(Vector3.Distance(Astronaut.transform.position, newposition) < 1)
			{
				animator.SetBool("Push",false);
				melee = false;
				astronaut_animator.SetBool("Pushed",false);
			}
			if(Input.GetButtonDown("Horizontal"))
			{
				animator.SetBool("Push",false);
				astronaut_animator.SetBool("Pushed",false);
				melee = false;
			}
			

			
		}
		else{

			animator.SetBool("Push",false);
;
		}

		if (EnemyHealth <= 0) {
			HealthBar.SetActive(false);
			animator.SetBool("Death",true);
			waitActive = true;
		}
		if (waitActive == true) {
			this.collider.enabled = false;
			CapsuleCollider collider = Parent.GetComponent<CapsuleCollider>();
			BoxCollider collider2 = Parent.GetComponent<BoxCollider>();
			Alien_AI script = Parent.GetComponent<Alien_AI>();
			script.enabled = false;
			collider.enabled = false;
			collider2.enabled = false;

			Parent.rigidbody.useGravity =false;
			//Parent.transform.position = Vector3.Lerp (Parent.transform.position, death_position, Time.deltaTime * .05f);	
		}
		HealthBar.transform.localScale = new Vector3(HealthSize, HealthBar.transform.localScale.y, HealthBar.transform.localScale.z);
	
	}
	// Update is called once per frame
	public void Take_Damage(float damage){
		EnemyHealth = EnemyHealth - damage;
	}
	void OnTriggerEnter(Collider other){
		if (other.gameObject.tag == "Bullet") {
			Take_Damage(other.GetComponent<Damage_to_Player>().Damage);

			HealthSize = (EnemyHealth * HealthSize) / (overallhealth);
			other.gameObject.SetActive(false);
		}
	
		if (other.gameObject.tag == "Player") {

			float side = Astronaut.transform.position.x - this.transform.position.x;
			if(side < 0){
				push_distance = 0 - push_distance;

			}

			newposition = new Vector3(Astronaut.transform.position.x + push_distance, Astronaut.transform.position.y, Astronaut.transform.position.z);
			melee = true;		
		}

	}
	void OnTriggerStay(Collider other){
		if(other.gameObject.tag == "Player"){
			melee = true;	
		}
	}
	void OnTriggerExit(Collider other){
		if (other.gameObject.tag == "Player") {
			boxcollider.size = new Vector3(originalsize,boxcollider.size.y,boxcollider.size.z);		
		}
	}



	IEnumerator AnimationWait(float time){
		yield return new WaitForSeconds(starter_delay);
		boxcollider.size = new Vector3(boxcollider_newsize,boxcollider.size.y,boxcollider.size.z);
		Astronaut.GetComponent<Player_Health> ().Take_Damage (Melee_Damage);
		yield return new WaitForSeconds(time);
		boxcollider.size = new Vector3(originalsize,boxcollider.size.y,boxcollider.size.z);

		playing = true;
	}
}
