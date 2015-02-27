using UnityEngine;
using System.Collections;

public class Bomb_Controller : MonoBehaviour {
	public Animator Dragon;
	public GameObject[] Things;
	public float Sleep = 6;
	public float GoSleep = 6;
	private bool ready = true;

	// Use this for initialization
	void Start(){
		foreach (GameObject thing in Things) {
			thing.SetActive(false);
		}
	}
	
	// Update is called once per frame
	void Update () {
		if(Dragon.GetBool("Barrel") == true){
			if(ready == true){
				StartCoroutine(AnimationWait());
				ready = false;
			}


		}
	}

	IEnumerator AnimationWait(){
		yield return new WaitForSeconds(Sleep);
		foreach (GameObject thing in Things) {
			thing.SetActive(true);
		}
		yield return new WaitForSeconds(GoSleep);
		foreach (GameObject thing in Things) {
			thing.SetActive(false);
		}
		ready = true;
	}

}
