using UnityEngine;
using System.Collections;

public class WreckingDoor : MonoBehaviour {

	public PlayerController pc; 
	public float maxSpeed = 20f;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter2D(Collider2D target){
		if (target.gameObject.tag == "Rock") {
			if(pc.rigidbody2D.velocity.x.CompareTo(maxSpeed) == 1 ){
				Destroy(gameObject);
			}
		}
	}
}
