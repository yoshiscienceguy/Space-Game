using UnityEngine;
using System.Collections;

public class light_flicker : MonoBehaviour {
	public float minFlickerSpeed = 1.0f;
	public float maxFlickerSpeed = 2.0f;

	// Update is called once per frame
	void Update(){
		StartCoroutine ("flicker");
	}
	IEnumerator flicker () {
		light.enabled = true;
		yield return new WaitForSeconds(Random.Range(minFlickerSpeed,maxFlickerSpeed));
		light.enabled = false;
		yield return new WaitForSeconds(Random.Range(minFlickerSpeed,maxFlickerSpeed));
	}
}
