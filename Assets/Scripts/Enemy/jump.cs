using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class jump : MonoBehaviour
{

		// Use this for initialization

//		private CharacterController character;
		float jumpTime;
		private float spawnTime = 0f;
		public float spawnReload = 30f;
		private float jumptimer = 0f;
		private float jumpBreak = 10f;
		private float attackTime = 0f;
		private float biteTime = 0f;
		private float biteCD = 15f;
		private float flameDmg = 2f;
		private float biteDmg = 20f;
		private float jumpSpeed = 15f;
		private float jumpLR = 20f;
		private float jumpPlayerSpd = 40f;
	private float stayOn = 4f;
	private float stayOnTime = 0f;
		public GameObject left;
		public GameObject right;
		public GameObject top;
		public GameObject sp1;
		public GameObject sp2;
	//	public GameObject sp3;
	//public GameObject sp4;
	//public GameObject sp5;
		private GameObject player;
		private bool jumpback = false;
		private bool jumpNow = false;
		private bool returnTop = false;
		private bool jumpTop = false;
		private bool jumpLeft = false;
		private bool jumpRight = false;
		private bool jumpPlayer = false;
		private bool forcejumpReset = false;
		private bool disJump = false;
		private bool canAttackPlayer = false;
		private bool startSpawn = false;
		private bool frenzyMode = false;
	private bool staying = false;

	private bool spawn1 = true;
	private bool spawn2 = true;
	private bool spawn3 = true;
	private bool spawn4 = true;


		private Vector3 adjustTop;
		private Vector3 oriPosition;
		private Vector3 playerPos;
		private Vector3 oriAngle;
		private Animator animator;
		private int curPlat = 1;
		private int nextPlat = 1;
		private ParticleSystem particlesystem;
		private EnemyHealth eh;
		private Player_Health ph;

	public GameObject[] enemies;
	private int count = 0;


		public bool attackingPlayer ()
		{
				return canAttackPlayer;
		}

		public float getflameDmg ()
		{
				return (float)flameDmg;
		}

		void Start ()
		{
				eh = GetComponent<EnemyHealth> ();
				oriAngle = transform.eulerAngles;
				player = GameObject.FindWithTag ("Player");
				ph = player.GetComponent <Player_Health> ();
				Physics.IgnoreCollision (player.collider, collider);
				particlesystem = (ParticleSystem)gameObject.GetComponentInChildren<ParticleSystem> ();
				particlesystem.enableEmission = false;
				//character = GetComponent<CharacterController> ();
				animator = GetComponent<Animator> ();
				oriPosition = transform.position;
				adjustTop = top.transform.position;
				adjustTop.y += 5f;
				jumptimer = Time.time + jumpBreak;
		biteTime = Time.time+ biteCD;
		}

//	void SpawnItems (){
//		if (spawn1 && getHP() < 0.8f) {
//			sp4.GetComponent<Deimos> ().Spawn ();
//			sp5.GetComponent<Deimos> ().Spawn ();
//			spawn1 = false;
//		}else if (spawn2 && getHP() < 0.6f) {
//			sp4.GetComponent<Deimos> ().Spawn ();
//			sp5.GetComponent<Deimos> ().Spawn ();
//			spawn2 = false;
//		}else if (spawn3 && getHP() < 0.4f) {
//			sp4.GetComponent<Deimos> ().Spawn ();
//			sp5.GetComponent<Deimos> ().Spawn ();
//			spawn3 = false;
//		}else if (spawn4 && getHP() < 0.2f) {
//			sp4.GetComponent<Deimos> ().Spawn ();
//			sp5.GetComponent<Deimos> ().Spawn ();
//			spawn4 = false;
//		}
//	}

	private float getHP(){
		return ((float)eh.HP / (float)eh.GetMaxHP ());
	}
		void FixedUpdate ()
		{
				if (!eh.dead) {
			//SpawnItems ();
						if (!startSpawn) {
								if ( getHP()< 0.8f) {
										startSpawn = true;
										spawnTime = Time.time + Random.Range (spawnReload, spawnReload * 2);
								}	
						}
						else {
								if (spawnTime < Time.time) {
//										sp1.GetComponent<Deimos> ().Spawn ();
//										sp2.GetComponent<Deimos> ().Spawn ();
									//	sp3.GetComponent<Deimos> ().Spawn ();
					if(count<enemies.Length){
					enemies[count++].SetActive(true);
					}
					if(count<enemies.Length){
						enemies[count++].SetActive(true);
					}
										spawnTime = Time.time + Random.Range (spawnReload, spawnReload * 2);
								}	
								if (!frenzyMode && (float)eh.HP / (float)eh.GetMaxHP () < 0.25f) {
										Debug.Log ("FRENZY MODE");
										frenzyMode = true;
										jumpBreak -= 4f;
					biteCD -= 2f;
										spawnReload -= 4f;
										flameDmg += 5f;
										jumpSpeed += 5f;
										biteDmg *= 2;
										jumpLR += 20f;
										jumpPlayerSpd += 20f;
										Debug.Log (jumpBreak);
								}
						}

//						if (forcejumpReset && jumptimer < Time.time) {
//								animator.SetBool ("Flying", false);
//								setJumpFalse ();	
//								jumptimer -= jumpBreak / 4.0f;
//								forcejumpReset = false;
//						}



						if (!disJump && jumptimer < Time.time) {
								//this.rigidbody.isKinematic = false;
								//Debug.Log ("I SHOULD JUMP");
								nextPlat = Random.Range (1, 4);
								if (nextPlat != curPlat) {
										//	rigidbody.useGravity = false;
										jumptimer = Time.time + jumpBreak;
										jumpNow = true;
										curPlat = nextPlat;
										if (curPlat != 1 && nextPlat != 1) {
												//		Debug.Log ("side to side jump");
												forcejumpReset = true;
										}
										animator.SetBool ("Flying", true);
										switch (curPlat) {
										case 1:
												jumpTop = true;
												jumpback = true;
												break;
										case 2:
												jumpLeft = true;
					//particlesystem = (ParticleSystem)gameObject.GetComponentInChildren<ParticleSystem>();
												particlesystem.enableEmission = true;
												break;
										case 3:
												jumpRight = true;
					//particlesystem = (ParticleSystem)gameObject.GetComponentInChildren<ParticleSystem>();
												particlesystem.enableEmission = true;
												break;
										case 4:
					//Debug.Log("ATTACK PLAYER");
					//this.collider.enabled=false;
												MessCollision (false);
												jumpPlayer = true;
												disJump = true;
												playerPos = player.transform.position;
												float dir = this.transform.position.x - playerPos.x;
//												if (dir > 0) {
//														transform.eulerAngles = (dir > 0) ? Vector3.up * 90 : Vector3.zero;
//												}
//												if (dir < 0) {
//														transform.eulerAngles = (dir < 0) ? Vector3.up * 180 : Vector3.zero;
//												}
					//particlesystem = (ParticleSystem)gameObject.GetComponentInChildren<ParticleSystem>();
					//particlesystem.enableEmission = true;
												break;
										default:
												setJumpFalse ();
												jumptimer = Time.time + jumpBreak;
												break;
										}
										;
								}
						} else 	if (!disJump && biteTime < Time.time) {
								MessCollision (false);
								jumpPlayer = true;
								jumpNow = true;
								disJump = true;
				stayOnTime = Time.time + Random.Range (stayOn, stayOn + 2f);;
								biteTime = Time.time + Random.Range (biteCD, biteCD + 5f);
								playerPos = player.transform.position;
								animator.SetBool ("Flying", true);
								float dir = this.transform.position.x - playerPos.x;
								if (dir > 0) {
										transform.eulerAngles = (dir > 0) ? Vector3.up * 90 : Vector3.zero;
								}
								if (dir < 0) {
										transform.eulerAngles = (dir < 0) ? Vector3.up * 180 : Vector3.zero;
								}
						}
						if (jumpNow) {
								if (jumpLeft) {
										if (Vector3.Distance (transform.position, left.transform.position) < 2f) {
												setJumpFalse ();
												animator.SetBool ("Flying", false);
												transform.position = left.transform.position;
												//rigidbody.velocity = Vector3.zero;
												//rigidbody.isKinematic = false;
												//	particlesystem.enableEmission = false;
										} else {
												float step = jumpLR * Time.deltaTime;
												transform.position = Vector3.MoveTowards (transform.position, left.transform.position, step);
						animator.SetBool ("Flying", true);

										}
			
								} else if (jumpRight) {
										if (Vector3.Distance (transform.position, right.transform.position) < 2f) {
												transform.position = right.transform.position;
												animator.SetBool ("Flying", false);
												setJumpFalse ();	
												//rigidbody.velocity = Vector3.zero;
												//rigidbody.isKinematic = false;//animator.SetBool("Idle",true);
						
										} else {
												float step = jumpLR * Time.deltaTime;
												transform.position = Vector3.MoveTowards (transform.position, right.transform.position, step);
						animator.SetBool ("Flying", true);
										}
										//	animator.SetBool("Flying",true);
								} else if (jumpTop) {
										//	animator.SetBool("Flying",true);
										float step = jumpSpeed * Time.deltaTime;
										if (Vector3.Distance (transform.position, adjustTop) < 5f) {
												transform.position = Vector3.MoveTowards (transform.position, top.transform.position, step);
												jumpback = false;
										} else if (jumpback) {
												transform.position = Vector3.MoveTowards (transform.position, adjustTop, step);
						animator.SetBool ("Flying", true);
										}
										if (Vector3.Distance (transform.position, top.transform.position) < 2f) {
												Debug.Log ("HIT TOP SWITCHING OFF");
												particlesystem.enableEmission = false;
												setJumpFalse ();
												animator.SetBool ("Flying", false);
												jumpback = true;
												//rigidbody.velocity = Vector3.zero;
												//rigidbody.isKinematic = true;
												//animator.SetBool("Idle",true);
												transform.position = top.transform.position;
						
										}
								} else if (jumpPlayer) {
										float step = jumpPlayerSpd * Time.deltaTime;
										transform.position = Vector3.MoveTowards (transform.position, playerPos, step);
										if (Vector3.Distance (transform.position, playerPos) < 3f) {
												transform.position = playerPos;
												animator.SetBool ("Flying", false);
												if (!animator.GetBool ("Bite")) {
														attackTime = Time.time + 2f;
														animator.SetBool ("Bite", true);
												} else {
														if (attackTime < Time.time) {
																//if(canAttack)
																if (!canAttackPlayer && Vector3.Distance (transform.position, player.transform.position) < 10f) {
																		Debug.Log ("DEAL DAMAGE TO PLAYER WOO");	
																		ph.Take_Damage ((float)biteDmg);
																		canAttackPlayer = true;
																}
																animator.SetBool ("Bite", false);
								staying = true;
								jumpPlayer = false;
																//animator.SetBool ("Flying", false);
//													jumpPlayer = false;
//													returnTop = true;
//													animator.SetBool ("Flying", true);
														}
						
												}
												
										}
					//Debug.Log(stayOnTime+" "+Time.time);

				}else if(staying && stayOnTime<Time.time){
					Debug.Log("asdasdasd");
					
					staying=false;
					returnTop = true;
					animator.SetBool ("Flying", true);
				} else if (returnTop) {
					canAttackPlayer = false;
										returnTop = false;
										animator.SetBool ("Flying", true);
										switch (curPlat) {
										case 1:
												jumpTop = true;
												jumpback = true;
												break;
										case 2:
												jumpLeft = true;
						//particlesystem = (ParticleSystem)gameObject.GetComponentInChildren<ParticleSystem>();
												particlesystem.enableEmission = true;
												break;
										case 3:
												jumpRight = true;
						//particlesystem = (ParticleSystem)gameObject.GetComponentInChildren<ParticleSystem>();
												particlesystem.enableEmission = true;
												break;
										}
//					float step = jumpPlayerSpd * Time.deltaTime;
//										transform.position = Vector3.MoveTowards (transform.position, top.transform.position, step);
//										if (Vector3.Distance (transform.position, top.transform.position) < 2f) {
//												curPlat = 1;
//												transform.position = top.transform.position;
//												MessCollision (true);
//												returnTop = false;
//												disJump = false;
//												setJumpFalse ();
//												transform.eulerAngles = oriAngle;
//												//rigidbody.isKinematic = true;
//												animator.SetBool ("Flying", false);
//												particlesystem.enableEmission = false;
//												canAttackPlayer = false;
//										}
									
								}
		
						}
				} else {
						//VICOTRY		
				}
		}

		void MessCollision (bool value)
		{
				left.collider.enabled = value;
				top.collider.enabled = value;
				right.collider.enabled = value;
		}

		void OnTriggerEnter (Collider other)
		{
		Debug.Log (other.gameObject.tag + "OnTriggerEnter " + other.name);
		if (other.gameObject.tag == "Bullet") {
			Debug.Log ("hurt");
			eh.Hurt (other.gameObject.GetComponent<Damage_to_Player>().Damage);
				}
		

		
		}

//	

		private void setJumpFalse ()
		{
				transform.eulerAngles = oriAngle;
				jumpRight = false;
				jumpNow = false;
				jumpLeft = false;
				jumpTop = false;
				disJump = false;
				//rigidbody.useGravity = true;
				//particlesystem.enableEmission = false;
				jumptimer = Time.time + jumpBreak;
				//	Debug.Log ("New Jump Timer : "+jumptimer);
		}

}
