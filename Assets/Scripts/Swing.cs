using UnityEngine;
using System.Collections;

public class Swing : MonoBehaviour {


	//private BoxCollider2D bc2D;
	// Use this for initialization
	void Start () {
		//bc2D = GetComponent<BoxCollider2D> ();
	}
	
	// Update is called once per frame
	void Update () {

	}

	void OnTriggerEnter2D(Collider2D target){

		if (target.gameObject.tag == "Head") {

			gameObject.layer = LayerMask.NameToLayer("Trigger");
		}
	}

	void OnTriggerExit2D(Collider2D target){
		if (target.gameObject.tag == "Head") {
			gameObject.layer = LayerMask.NameToLayer("Ground");
		}
	}


	
}
