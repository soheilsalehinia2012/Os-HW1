using UnityEngine;
using System.Collections;

public class Above : MonoBehaviour {
	
	public PlayerController pc;
	public SinPlatform sPlat;
	private float PlayerPosX;
	private	float PlayerPosY;
	private	float PlayerdeltaX;
	private BoxCollider2D bc;
	private bool flag = false;
//	private float sPlatSpeed;
	
	// Use this for initialization
	void Start () {
		bc = GetComponent<BoxCollider2D> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (pc) {
			PlayerPosX = pc.transform.position.x;
			PlayerPosY = pc.transform.position.y;
			PlayerdeltaX = PlayerPosX - GetPositionX ();
			
			if(!Input.GetKey ("left") && !Input.GetKey ("right") && flag){
				bc.size = new Vector2(0.9963388f,1.356318f);
				flag = false;
			}
			if(sPlat){
				//sPlatSpeed = sPlat.rigidbody2D.velocity.x;
			}
			//print (sPlatSpeed);
		}
		
		//sPlatSpeed = sPlat.rigidbody2D.velocity.x;

		
	}
	
	float GetPositionX(){
		return transform.position.x;
	}
	
	float GetPositionY(){
		return transform.position.y;
	}
	
	float GetPositionZ(){
		return transform.position.z;
	}
	
	// Staying On Platform
	void OnTriggerStay2D(Collider2D target){
		if (target.gameObject.name == "Player" && pc ) {
			if (!Input.GetKey ("left") && !Input.GetKey ("right") && !Input.GetButtonDown ("Jump") ) {
				target.gameObject.transform.position = new Vector3 (GetPositionX () + PlayerdeltaX, GetPositionY (), target.gameObject.transform.position.z);
			} 
			else if(Input.GetButtonDown ("Jump")){
				
				//print ("11");
				bc.size = new Vector2(0.9963388f,0.07f);
				target.gameObject.transform.position = new Vector3 (GetPositionX () + PlayerdeltaX, PlayerPosY, target.gameObject.transform.position.z);
				flag = true;
				
				
			}
			if(pc){
				
				if(pc.tag == "Flubber"){
					if(target.gameObject.rigidbody2D.velocity.y > 0){
						pc.SetFlubberJumpForce(9f);
					}
					else{
						pc.SetFlubberJumpForce(7f);
					}
				}
				
				/*if((Input.GetKey ("left") || Input.GetKey ("right")) && !Input.GetButtonDown ("Jump") && sPlat){
					
					if(sPlatSpeed > 0f && Input.GetKey ("right")){
						//print("ali");
						pc.setFlubberSpeed(sPlatSpeed * 1.5f);
						pc.setRockSpeed(sPlatSpeed * 1.5f);
					}
					if(sPlatSpeed > 0f && Input.GetKey ("left")){
						pc.setFlubberSpeed(sPlatSpeed * 0.75f);
						pc.setRockSpeed(sPlatSpeed * 0.75f);
					}
					if(sPlatSpeed < 0f && Input.GetKey ("right")){
						pc.setFlubberSpeed(-sPlatSpeed * 0.75f);
						pc.setRockSpeed(-sPlatSpeed * 0.75f);
					}
					if(sPlatSpeed < 0f && Input.GetKey ("left")){
						pc.setFlubberSpeed(-sPlatSpeed * 1.5f);
						pc.setRockSpeed(-sPlatSpeed * 1.5f);
					}
					
					
				}*/
			}
			
			
			
		}
		
		
	}
}

