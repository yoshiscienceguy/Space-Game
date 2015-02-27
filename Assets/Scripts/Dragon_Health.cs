using UnityEngine;
using System.Collections;

public class Dragon_Health : MonoBehaviour {
	public GameObject HealthBar;
	public float Health = 1000;
	public GameObject Player;
	public bool dead = false;
	public Animator Dragonchild;
	private float overallhealth;
	private float HealthSize;

	// Use this for initialization
	void Start () {
		overallhealth = Health;
		HealthSize = HealthBar.transform.localScale.x;
	
	}
	
	// Update is called once per frame
	void Update () {
		HealthSize = (Health * HealthSize) / (overallhealth);
		HealthBar.transform.localScale = new Vector3(HealthSize, HealthBar.transform.localScale.y, HealthBar.transform.localScale.z);
	}

	public void Take_Damage(float damage){
		if (Health - damage > 0) {
			Health -= damage;
		}

		else{
			Health = 0;
			dead = true;
			GetComponent<Animator>().SetBool("Dead",true);
			Dragonchild.SetBool("Dead",true);
			StartCoroutine(FireRate());
		}
	}

	IEnumerator FireRate(){
		
		yield return new WaitForSeconds(10);
		Application.LoadLevel(0);
		
	}
}
