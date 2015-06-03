using UnityEngine;
using System.Collections;

public class RockWalking : MonoBehaviour {
	private float speed = 4f;
	public float downSpeed = 3f;
	public bool jump = false;
	public bool unArmed = true;


	public float s;
	public float sX;

	private float jumpForce = 7f;
	public Transform groundLine1;
	public Transform groundLine2;
	public Transform groundLine3;
	private bool grounded1 = false;
	private bool grounded2 = false;
	private bool grounded3 = false;

	private Rigidbody2D rb2d;
	private RockController controller;

	// Use this for initialization
	void Awake () {
		controller = GetComponent<RockController> ();
		rb2d = GetComponent<Rigidbody2D> ();

	}
	
	// Update is called once per frame
	void Update () {

		s = rb2d.velocity.y;
		sX = rb2d.velocity.x;
		//print (sX);



		grounded1 = Physics2D.Linecast(transform.position, groundLine1.position, 1 << LayerMask.NameToLayer("Ground"));
		grounded2 = Physics2D.Linecast(transform.position, groundLine2.position, 1 << LayerMask.NameToLayer("Ground"));
		grounded3 = Physics2D.Linecast(transform.position, groundLine3.position, 1 << LayerMask.NameToLayer("Ground"));

		
		if ((controller.moving.y == 1) && (grounded1 || grounded2 || grounded3)) {
			jump = true;
		}

		if (controller.moving.y == -1) {
			rigidbody2D.AddForce (new Vector2(0f , -downSpeed));
		}

		if (controller.moving.x == 1) {
			transform.localScale = new Vector3 (1f ,1f, 1f);
			rigidbody2D.velocity = new Vector2(speed , rigidbody2D.velocity.y);
		}

		if (controller.moving.x == -1) {
			transform.localScale = new Vector3 (-1f ,1f, 1f);
			rigidbody2D.velocity = new Vector2(-speed , rigidbody2D.velocity.y);
		}

		if (controller.moving.x == 0 && rigidbody2D.velocity.y == 0) {
			rigidbody2D.velocity = new Vector2(0f , rigidbody2D.velocity.y);
		}
		if (controller.moving.x == 0 && rigidbody2D.velocity.y != 0) {
			rigidbody2D.velocity = new Vector2(rigidbody2D.velocity.x / 1.5f , rigidbody2D.velocity.y);
		}




	}

	void FixedUpdate(){
		if (jump)
		{
			rb2d.velocity = new Vector2(rb2d.velocity.x, jumpForce);
			jump = false;
		}
	}


		void OnCollisionEnter2D(Collision2D target){
			if (target.gameObject.tag == "Glass") {
				if(controller.moving.y == -1){//when stay on glass and push down it will be false
					Destroy(target.gameObject);//because it is OnCollisionEnter
				}
			}


		if (target.gameObject.name == "2x4Building" && controller.moving.x != 0) {
			rigidbody2D.velocity = new Vector2 (0, 5f);
		}

		if (target.gameObject.name == "SpringSurface") {//Bug in Speed
			//	rigidbody2D.velocity = new Vector2(sX , rigidbody2D.velocity.y);
			jumpForce = 12f;


		} else if (target.gameObject.name == "Oil") {//Oil Size = 20
			speed = 16f;
			jumpForce = 9f;
		} else {
			jumpForce = 7f;
		}


	}

	void OnCollisionExit2D(Collision2D target){
		if (target.gameObject.name == "Oil" && rigidbody2D.velocity.y == 0) {
			speed = 4f;
		}
	}

	void OnTriggerEnter2D(Collider2D target){
		if (target.gameObject.name == "Ground") {
			speed = 4f;
		}
	}

	public void SetJumpForce(float jf){
		jumpForce = jf;
	}
	
	public float GetJumpForce(){
		return jumpForce;
	}

	public void setSpeed(float s){
		speed = s;
	}
	
	public float getSpeed(){
		return speed;
	}
	

}
