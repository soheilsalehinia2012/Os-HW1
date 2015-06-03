using UnityEngine;
using System.Collections;

public class WoodSpring : MonoBehaviour {

	private float jumpForce = 0.25f;
	public Spring spring; 
	//private float placeX;
	//private float placeY;

	// Use this for initialization
	void Start () {
		//placeX = transform.position.x;
		//placeY = transform.position.y;
	}
	
	// Update is called once per frame
	void Update () {
		/*if (transform.position.y < -3 || transform.position.x > 332f || transform.position.x < 320f) {
			transform.position = new Vector3(placeX,placeY+2f,transform.position.z);
			rigidbody2D.velocity = new Vector2(0f,rigidbody2D.velocity.y);
		}*/
	}

	void OnCollisionExit2D(Collision2D target){
		if (target.gameObject.name == "SpringSurface") {
			rigidbody2D.AddForce(new Vector2(0f, jumpForce));
		}
	}

	void OnCollisionEnter2D(Collision2D target){
		if (target.gameObject.name == "SpringSurface") {
			gameObject.rigidbody2D.mass = 0.001f;
		}

		if (target.gameObject.name == "RootFloor")
			gameObject.rigidbody2D.mass = 1f;
	}


		
		
	
}
