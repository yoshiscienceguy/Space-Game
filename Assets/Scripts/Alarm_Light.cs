using UnityEngine;
using System.Collections;

public class Alarm_Light : MonoBehaviour {

	// Use this for initialization
	Light siren;
	public float intervalTime = .1f;
	float intervalTimer = 0f;
	bool isON;

	void Start(){
		siren = gameObject.light;
	}

	void Update(){
		intervalTimer += Time.deltaTime;
		if (intervalTimer > intervalTime) {
			isON = !isON;
			if(isON){
				light.intensity = 6;
			}
			else{
				light.intensity = 0;
			}
			intervalTimer = 0f;
		}
	}
}
