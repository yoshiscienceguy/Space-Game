using UnityEngine;
using System.Collections;

public class Deimos : MonoBehaviour {

	public GameObject[] enemies;	
	//private jump lol ;

	// Use this for initialization
	void Start () {
	//	InvokeRepeating ("Spawn", spawnDelay, spawnTime);
		//lol = GameObject.FindObjectOfType<jump>();

	}

	// Update is called once per frame
	void FixedUpdate () {
	
	}

	public void Spawn ()
	{
		// Instantiate a random enemy.
		int enemyIndex = Random.Range(0, enemies.Length);
		GameObject a = Instantiate(enemies[enemyIndex], transform.position, transform.rotation) as GameObject;
		a.transform.localScale = new Vector3 (3f, 3f, 3f);
		try{
			a.GetComponent <Alien_AI>().range_aiming = 10f;
		}catch{
				}
		//Destroy (a, 5f);
		//lol.Add (a);
		// Play the spawning effect from all of the particle systems.
//		foreach(ParticleSystem p in GetComponentsInChildren<ParticleSystem>())
//		{
//			p.Play();
//		}
	}
}
