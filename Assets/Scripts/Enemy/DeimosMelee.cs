using UnityEngine;
using System.Collections;

public class DeimosMelee : MonoBehaviour {

	private ParticleSystem particlesystem;
	private GameObject player;
	private float attackTime;
	public float attackReload = 0.1f;
	private jump a;
	
	private Player_Health ph;
	// Use this for initialization
	void Start () {
		attackTime = Time.time;
		player = GameObject.FindWithTag("Player");
		ph = player.GetComponent <Player_Health>();
		particlesystem = (ParticleSystem)gameObject.GetComponentInParent<ParticleSystem> ();
		a = gameObject.GetComponentInParent<jump> ();

		Physics.IgnoreCollision (a.collider, collider);
	}
	
	// Update is called once per frame
	void Update () {

//		if (!particlesystem.enableEmission) {
//			gameObject.layer = 13;
//		}
	}

	void FixedUpdate(){
		if (particlesystem.enableEmission) {
			//Debug.Log( Vector3.Angle(transform.position,player.transform.position)+" ;;; " + Vector3.Distance(player.transform.position,transform.position));
			//	gameObject.layer = 14;
			//if(Vector3.Distance(player.transform.position,transform.position)<20f && Vector3.Angle(transform.position,player.transform.position)>7f && Vector3.Angle(transform.position,player.transform.position)<9f){
			//Debug.Log( Vector3.Angle(transform.position,player.transform.position)+" ;;; " + Vector3.Distance(player.transform.position,transform.position));
			if(Vector3.Distance(player.transform.position,a.transform.position)<12f ){

				if(!a.attackingPlayer()){
					if(attackTime<Time.time){
						Debug.Log ("DEALING FIRE DeimosMelee  PS is " + particlesystem.enableEmission);
						ph.Take_Damage((float)a.getflameDmg());
						//Debug.Log ("DeimosMelee " + other.name + " PS is " + particlesystem.enableEmission);
						attackTime = Time.time +attackReload;
					}
				}
			}
			
			
		}
//		if (particlesystem.enableEmission) {
//			//	gameObject.layer = 14;
//			if(other.name=="Astronaut"){
//				if(a.attackingPlayer()){
//					if(attackTime<Time.time){
//						Debug.Log ("DeimosMelee " + other.name + " PS is " + particlesystem.enableEmission);
//						attackTime = Time.time +attackReload;
//					}
//				}
//			}
//			
//			
//		}
	}

	void OnTriggerStay(Collider other) {

		if (particlesystem.enableEmission) {
			//Debug.Log ("DeimosMelee " + other.name + " PS is " + particlesystem.enableEmission + " " + a.attackingPlayer());
		//	gameObject.layer = 14;
			if(other.name=="Astronaut"){
				if(!a.attackingPlayer()){
				if(attackTime<Time.time){
					//Debug.Log ("DeimosMelee " + other.name + " PS is " + particlesystem.enableEmission);
					attackTime = Time.time +attackReload;
				}
				}
			}
			
			
		}
	}

	void OnTriggerEnter(Collider other) {
		if (particlesystem.enableEmission) {
		//	Debug.Log ("DeimosMelee " + other.name + " PS is " + particlesystem.enableEmission + " " + a.attackingPlayer());
		//	gameObject.layer = 14;
			if(other.name=="Astronaut"){
				if(!a.attackingPlayer()){
			if(attackTime<Time.time){
			//	Debug.Log ("DeimosMelee " + other.name + " PS is " + particlesystem.enableEmission);
				attackTime = Time.time +attackReload;
			}
			}
			}
						
				}
	}
	
}
