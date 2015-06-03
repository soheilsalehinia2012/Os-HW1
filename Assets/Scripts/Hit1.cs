using UnityEngine;
using System.Collections;

public class Hit1 : MonoBehaviour {

	private Swing swing;
	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D(Collider2D target){
		/*if (target.gameObject.tag == "Swingable") {
			target.rigidbody2D.fixedAngle = true;
		}*/
	}
	
}
