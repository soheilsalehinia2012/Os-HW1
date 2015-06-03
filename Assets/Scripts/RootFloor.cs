using UnityEngine;
using System.Collections;

public class RootFloor : MonoBehaviour {

	public PlayerController pc;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	/*void OnCollisionEnter2D(Collision2D target){
		if (target.gameObject.name == "Player") {
			if(target.gameObject.tag == "Rock"){
				pc.speed = 4f;
			}
			if(target.gameObject.tag == "")
		}
	}*/
}
