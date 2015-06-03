using UnityEngine;
using System.Collections;

public class XOPlatform : MonoBehaviour {

	public PlayerController pc;
	public bool Down = false;
	public bool Up = false;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnCollisionEnter2D(Collision2D target){
		if (target.gameObject.tag == "Flubber") {
			pc.disableHorizental();
			if(Down){
				pc.rigidbody2D.velocity = new Vector2(10f,20f);
			}else if(Up){
				pc.rigidbody2D.velocity = new Vector2(10f,-20f);
			}
		}
	}
}
