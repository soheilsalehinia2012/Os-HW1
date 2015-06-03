using UnityEngine;
using System.Collections;

public class Key : MonoBehaviour {

	private Animator animator;
	public bool sticky;
	public bool down;

	private bool onWood = false;
	// Use this for initialization
	void Start () {
		animator = GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerStay2D(Collider2D target){
		if (target.gameObject.name == "Wood" || target.gameObject.name == "Iron") {
			onWood = true;
		}
		animator.SetInteger ("AnimState", 1);
		down = true;
	}


	void OnTriggerExit2D(Collider2D target){
		if (target.gameObject.name == "Wood" || target.gameObject.name == "Iron") {
			onWood = false;
		}
		if (!sticky && !onWood) {
			animator.SetInteger ("AnimState", 0);
			down = false;
		} 
	}

	public bool GetDown(){
		return down;
	}
}
