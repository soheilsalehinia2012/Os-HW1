using UnityEngine;
using System.Collections;

public class WoodSwing : MonoBehaviour {


	public float vY;
	public float vX;
	public float pX;
	public float pY;
	private Rigidbody2D wrb2d;
	// Use this for initialization
	void Start () {
		wrb2d = GetComponent<Rigidbody2D> ();
		pX = transform.position.x;
		pY = transform.position.y;
	}
	
	// Update is called once per frame
	void Update () {

		vX = wrb2d.velocity.x;
		vY = wrb2d.velocity.y;

	}

	void OnCollisionExit2D(Collision2D target){
		if (target.gameObject.name == "SwingFloor" && vY > 7f)
			wrb2d.velocity = new Vector2 (vX * 1.5f, vY);
	
	}

	void OnTriggerEnter2D(Collider2D target){
		if (target.gameObject.name == "DestroyWood") {
			wrb2d.velocity = new Vector2(-0.2f,0);
			transform.position = new Vector3(pX, pY+5f, transform.position.z);
		}
	}
}
