using UnityEngine;
using System.Collections;

public class Copy_CAT : MonoBehaviour {

	public GameObject Player;
	public GameObject Guns;
	public GameObject These_Guns;
	public GameObject Suits;
	public GameObject These_Suits;
	private Animator player_animator;
	private Animator animator;
	// Use this for initialization
	void Start () {
		player_animator = Player.GetComponent<Animator>();;
		animator = GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {
		
		animator.SetBool ("Crouch",player_animator.GetBool("Crouch"));
		animator.SetBool ("Pistol",player_animator.GetBool("Pistol"));
		animator.SetBool ("Electro",player_animator.GetBool("Electro"));
		animator.SetBool ("SMG",player_animator.GetBool("SMG"));
		animator.SetBool ("LMG",player_animator.GetBool("LMG"));

		for(int i = 0; i<Guns.transform.childCount; i++){
			GameObject child = Guns.transform.GetChild(i).gameObject;
			GameObject copy_child = These_Guns.transform.GetChild(i).gameObject;
			copy_child.SetActive(child.activeSelf);
		}

		for(int i = 0; i<Suits.transform.childCount; i++){
			GameObject child = Suits.transform.GetChild(i).gameObject;
			GameObject copy_child = These_Suits.transform.GetChild(i).gameObject;
			copy_child.SetActive(child.activeSelf);
		}
	}
}
