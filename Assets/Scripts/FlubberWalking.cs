using UnityEngine;
using System.Collections;

public class FlubberWalking : MonoBehaviour {
	private float speed = 8f;
	//public float downSpeed = 2f;
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
	//private bool sight1 = false;
	//private bool sight2 = false;
	//public Transform sightLine1;
	//public Transform sightLine2;
	
	private Rigidbody2D rb2d;
	private FlubberController controller;
	
	// Use this for initialization
	void Awake () {
		controller = GetComponent<FlubberController> ();
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
		//sight1 = Physics2D.Linecast(transform.position, sightLine1.position, 1 << LayerMask.NameToLayer("Wall"));
		//sight2 = Physics2D.Linecast(transform.position, sightLine2.position, 1 << LayerMask.NameToLayer("Wall"));
		
		//if (sight1 || sight2) {
			//print ("if");
			//controller.moving.x = 0;
		//}

		if ((controller.moving.y == 1) && (grounded1 || grounded2 || grounded3)) {
			jump = true;
		}
		
		//if (controller.moving.y == -1) {
			//forceY = -downSpeed;
			//rigidbody2D.velocity = new Vector2(0f , -5f);
		//}
		
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
	

	void OnTriggerEnter2D(Collider2D target){
		if (target.gameObject.name == "FlubberPlatform") {
			speed = 24f;
		}
	}

	void OnCollisionEnter2D(Collision2D target){
		if (target.gameObject.name == "RootFloor") {
			speed = 8f;
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


	//void OnTriggerStay2D(Collider2D target){
	//	if (target.gameObject.name == "Wall") {
			//print ("if");
			//controller.moving.x = 0;
		//}
	//}
	/*void OnCollisionEnter2D(Collision2D target){
		if (target.gameObject.tag == "Glass") {
			if(controller.moving.y == -1){//when stay on glass and push down it will be false
				Destroy(target.gameObject);//because it is OnCollisionEnter
			}
		}
		
		if (target.gameObject.name == "Ground") {
			
			rigidbody2D.velocity = new Vector2(sX , rigidbody2D.velocity.y);
		}
		
		if (target.gameObject.name == "SpringSurface") {//Bug in Speed
			//	rigidbody2D.velocity = new Vector2(sX , rigidbody2D.velocity.y);
			jumpForce = 1800f;
			
			
		} else if (target.gameObject.name == "Oil") {//Oil Size = 20
			speed = 40f;
			maxVelocity.x *= 5f;
			jumpForce = 1300f;
		} else {
			jumpForce = 1000f;
		}
	}
	
	void OnCollisionExit2D(Collision2D target){
		speed = 20f;
		if (target.gameObject.name == "Oil") {
			maxVelocity.x /= 5f;
		}
	}*/
	

}

