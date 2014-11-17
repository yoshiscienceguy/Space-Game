using UnityEngine;
using System.Collections;

public class EnemyHealth : MonoBehaviour
{

		public int HP;
	private int maxHP;
		public int maxLoot;
		public lootOptions Loot;
	GUIText GUIDamage ;

	void Start () {
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

	public int GetMaxHP(){
		return maxHP;
	}

	public void SetMaxHP(int value){
		maxHP = value;
	}
		public void Hurt (int Damage)
		{
				Debug.Log ("DEALING DAMAGE TO!");
				HP -= Damage;
		//GUIDamage.text = "" + Damage;
		//GUI.Label (Rect (10, 10, 100, 20), "Hello World!");
		//Instantiate(GUIDamage, Camera.main.WorldToViewportPoint(gameObject.transform.position), Quaternion.identity);
		//Destroy(GUIPrefab, 1);
				if (HP <= 0) {
						//perform animation
						GameObject.FindWithTag ("Player").GetComponent<PlayerController> ().GetLoot (RandomLoot ());
						Destroy (gameObject);		
				}
		}

}
