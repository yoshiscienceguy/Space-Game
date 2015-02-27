using UnityEngine;
using System.Collections;

public class EnemyHealth : MonoBehaviour
{

		public float HP;
	private float maxHP;
		public int maxLoot;
		public lootOptions Loot;
	public Transform HealthBar;
	private Quaternion oriRotate;
	private float oriX;
	public bool dead = false;

	void Start () {
		oriRotate = HealthBar.rotation;
		oriX = HealthBar.localScale.x;
		maxHP = HP;
	}

		public enum lootOptions
		{
				None,
				Mat,
				Fuel,
				Both
		}

		string RandomLoot ()
		{
		string loot = "";
		if (Loot == lootOptions.Both || Loot == lootOptions.Mat) {
			loot+="0:"+Random.Range(1,maxLoot)+";";		
		}
		if (Loot == lootOptions.Both || Loot == lootOptions.Fuel) {
			loot+="1:"+Random.Range(1,maxLoot)+";";		
		}
		return loot;
		}

	public float GetMaxHP(){
		return maxHP;
	}

	void FixedUpdate(){
//		if (Random.Range (1, 100) < 5) {
//			Hurt(5);		
//		}
	}

	void LateUpdate(){
		HealthBar.transform.rotation = oriRotate;

	}

	public void SetMaxHP(float value){
		maxHP = value;
	}

		public void Hurt (float Damage)
		{
		if (!dead) {
						//	Debug.Log (oriX+" DEALING DAMAGE TO! " + Damage + " " + HP + " " + maxHP + " " + (HP / maxHP));
						HP -= Damage;
						Vector3 tmp = HealthBar.transform.localScale;
						tmp.x = oriX * ((float)HP / (float)maxHP);
						//	Debug.Log(tmp.x);
						HealthBar.localScale = tmp;
				


						//GUIDamage.text = "" + Damage;
						//GUI.Label (Rect (10, 10, 100, 20), "Hello World!");
						//Instantiate(GUIDamage, Camera.main.WorldToViewportPoint(gameObject.transform.position), Quaternion.identity);
						//Destroy(GUIPrefab, 1);
						if (HP <= 0) {
								dead = true;
								//perform animation
								Debug.Log ("HP IS 0");
								//GameObject.FindWithTag ("Player").GetComponent<PlayerController> ().GetLoot (RandomLoot ());
								try {
										gameObject.GetComponent<Animator> ().SetBool ("Death", true);
								} catch {
								}		
								//gameObject.
								//Destroy (gameObject);	
								Destroy (gameObject, 5f);		
						}
				}
		}

}
