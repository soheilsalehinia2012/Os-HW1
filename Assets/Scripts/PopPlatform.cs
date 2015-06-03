using UnityEngine;
using System.Collections;

public class PopPlatform : MonoBehaviour {

	public PlayerController pc;
	public bool right = false;
	public bool left = false;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerStay2D(Collider2D target){

		if (target.gameObject.tag == "Flubber") {
			if(Input.GetButtonDown ("Jump")){
				pc.disableHorizental ();
				if(right){	
					target.rigidbody2D.velocity = new Vector2(-10f,7f);
				}else if(left){
					target.rigidbody2D.velocity = new Vector2(+10f,7f);
				}
			}
		}
	}
	
}
