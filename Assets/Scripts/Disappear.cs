using UnityEngine;
using System.Collections;

public class Disappear : MonoBehaviour {
	private Color colorStart;
	private Color colorEnd;
	public float duration;
	private bool ready = false;
	// Use this for initialization
	void Start () {
		colorStart = renderer.material.color;
		colorEnd = new Color (colorStart.r, colorStart.g, colorStart.b, 0.0f);

	}
	
	// Update is called once per frame
	void Update () {
		if (ready) {
			FadeOut();		
		}
	
	}

	void FadeOut(){
		for(float t = 0; t< duration; t+=Time.deltaTime){
			renderer.material.color = Color.Lerp(colorStart,colorEnd, t/duration);
		}
	}

	void OnTriggerStay(){
		ready = true;
	}
}
