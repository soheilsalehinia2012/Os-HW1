using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	private bool Rock = false;
	private bool Flubber = false;
	private bool Ballon = false;
	private bool grounded1 = false;
	private bool grounded3 = false;
	private bool grounded2 = false;
	public Transform groundLine1;
	public Transform groundLine2;
	public Transform groundLine3;
	[HideInInspector] public bool facingRight = true;
	[HideInInspector] public bool jump = false;
	[HideInInspector] public bool horizental = true;
	//[HideInInspector] public bool move = false;
	[HideInInspector] public float speed = 0f;
	[HideInInspector] public float jumpForce = 0f;
	[HideInInspector] public bool unArmed = true;
	[HideInInspector] public float downSpeed = 0f;
	private Animator animator;
	private bool collisionSpringSurface = false;
	private bool collisionOil = false;
	private bool collisionFlubberPlatform = false;
	//private bool collisionSinPlatform = false;

	private float defaultRockSpeed = 4f;
	private float defaultFlubberSpeed = 8f;
	private float defaultBallonSpeed = 8f;
	private float defaultRockJumpForce = 7f;
	private float defaultFlubberJumpForce = 7f;
	private float defaultBallonJumpForce = 7f;

	//private BoxCollider2D boxCollider2D;

	// Use this for initialization
	void Start () {
		animator = GetComponent<Animator> ();
		//boxCollider2D = GetComponent<BoxCollider2D> ();
		Rock = true;
	}
	
	// Update is called once per frame
	void Update () {


		grounded1 = Physics2D.Linecast(transform.position, groundLine1.position, 1 << LayerMask.NameToLayer("Ground"));
		grounded2 = Physics2D.Linecast(transform.position, groundLine2.position, 1 << LayerMask.NameToLayer("Ground"));
		grounded3 = Physics2D.Linecast(transform.position, groundLine3.position, 1 << LayerMask.NameToLayer("Ground"));
		//print (jump);
		if((grounded1 || grounded2 || grounded3)){
			if(!Input.GetKey ("left") && !Input.GetKey ("right")){
				rigidbody2D.velocity = new Vector2(0f,rigidbody2D.velocity.y);
			}
		}
		if (Input.GetButtonDown ("Jump") && (grounded1 || grounded2 || grounded3)) {
			jump = true;
			//print ("2");
		}

		if (Input.GetButtonDown ("Rock")) {
			Rock = true;
			Flubber = false;
			Ballon = false;
			animator.SetInteger ("AnimState", 0);
		} else if (Input.GetButtonDown ("Flubber")) {
			Flubber = true;
			Rock = false;
			Ballon = false;
			animator.SetInteger ("AnimState", 1);
		} else if (Input.GetButtonDown ("Ballon")) {
			Flubber = false;
			Rock = false;
			Ballon = true;
			animator.SetInteger ("AnimState", 2);
		}

		if (jump) {
			//print("if");
			rigidbody2D.velocity = new Vector2(rigidbody2D.velocity.x, jumpForce);
			jump = false;
		}
		if (horizental) {
			if (Input.GetKey ("left")) {
				transform.localScale = new Vector3 (-1f, 1f, 1f);
				rigidbody2D.velocity = new Vector2 (-speed, rigidbody2D.velocity.y);
			}
			if (Input.GetKey ("right")) {
				transform.localScale = new Vector3 (1f, 1f, 1f);
				rigidbody2D.velocity = new Vector2 (speed, rigidbody2D.velocity.y);
			}
		}
		if (Input.GetKey ("down")) {
			rigidbody2D.AddForce (new Vector2(0f , -downSpeed));
		}

		if (Rock) {
			//boxCollider2D.size = new Vector2(1f,1f);
			gameObject.tag = "Rock";
			if(collisionOil){
				speed = 16f;
				jumpForce = 9f;
			}else if(collisionSpringSurface) {
				jumpForce = 12f;
				speed = 4f;
			}else{
				speed = defaultRockSpeed;
				jumpForce = defaultRockJumpForce;
			}



			rigidbody2D.mass = 3f;
			downSpeed = 100f;
		} else if (Flubber) {
			gameObject.tag = "Flubber";
			//boxCollider2D.size = new Vector2(1f,1f);
			if(collisionFlubberPlatform){
				speed = 24;
			}else{
				speed = defaultFlubberSpeed;
			}

			jumpForce = defaultFlubberJumpForce;

			downSpeed = 0f;
			rigidbody2D.mass = 1f;
		} else if (Ballon) {
			gameObject.tag = "Ballon";
			//boxCollider2D.size = new Vector2(1f,1f);

			jumpForce = 7f;
			speed = 8f;
			downSpeed = 0f;
			rigidbody2D.mass = 0.5f;
		}

	}




	void OnCollisionExit2D(Collision2D target){
		if (Rock) {
			if (target.gameObject.name == "Oil" && rigidbody2D.velocity.y == 0) {
				speed = 4f;
			}
		}
	}




	//OnTrriger Statrs
	void OnTriggerEnter2D(Collider2D target){
		if (Rock) {
			if (target.gameObject.name == "Ground") {
				defaultRockSpeed = 4f;
				defaultFlubberJumpForce = 7f;
				//horizental = true;
			}
		}
		if (Flubber) {
			if(target.gameObject.name == "Ground"){
				//print ("GroundLine");
				defaultFlubberSpeed = 8f;
				defaultFlubberJumpForce = 7f;
				//horizental = true;
			}
			if (target.gameObject.name == "FlubberPlatform") {
				collisionFlubberPlatform = true;
			}else{
				collisionFlubberPlatform = false;

			}
			if (target.gameObject.name == "ExitPopPlatform") {
				enableHorizental();
			}
		}

	}//OnTrriger Ends




	// OnCollision Enters Start
	void OnCollisionEnter2D(Collision2D target){
		if (Rock) {
			if (target.gameObject.tag == "Glass") {
				if (Input.GetKey ("down")) {//when stay on glass and push down it will be false
					Destroy (target.gameObject);//because it is OnCollisionEnter
				}
			}
		
			if (target.gameObject.name == "SpringSurface") {//Bug in Speed
				collisionSpringSurface = true;
			} else {
				collisionSpringSurface = false;
			}

			if (target.gameObject.name == "Oil") {//Oil Size = 20
				collisionOil = true;
			} else
				collisionOil = false;
		}
	}

	//OnCollisionEnters End
	

	public void SetRockJumpForce(float jf){
		defaultRockJumpForce = jf;
	}
	
	public float GetRockJumpForce(){

		return defaultRockJumpForce;
	}
	
	public void setRockSpeed(float s){
		defaultRockSpeed = s;
	}
	
	public float getRockSpeed(){
		return defaultRockSpeed;
	}


	public void SetFlubberJumpForce(float jf){
		defaultFlubberJumpForce = jf;
	}
	
	public float GetFlubberJumpForce(){
		
		return defaultFlubberJumpForce;
	}
	
	public void setFlubberSpeed(float s){
		defaultFlubberSpeed = s;
	}
	
	public float getFlubberSpeed(){
		return defaultFlubberSpeed;
	}

	public void SetBallonJumpForce(float jf){
		defaultBallonSpeed = jf;
	}
	
	public float GetBallonJumpForce(){
		
		return defaultBallonJumpForce;
	}
	
	public void setBallonSpeed(float s){
		defaultBallonSpeed = s;
	}
	
	public float getBallonSpeed(){
		return defaultBallonSpeed;
	}

	public void disableHorizental(){
		horizental = false;
	}

	public void enableHorizental(){
		horizental = true;
	}



}
