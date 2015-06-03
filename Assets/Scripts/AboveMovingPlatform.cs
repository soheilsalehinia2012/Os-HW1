using UnityEngine;
using System.Collections;

public class AboveMovingPlatform : MonoBehaviour {

	public PlayerController pc;
	private float fPosX;
	//private	float fPosY;
	private	float fdeltaX;
	//private BoxCollider2D bc;
	//private bool flag = false;
	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		if (pc) {
			fPosX = pc.transform.position.x;
			//fPosY = fcon.transform.position.y;
			fdeltaX = fPosX - GetPositionX ();
		}
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

	void OnTriggerStay2D(Collider2D target){
		if (target.gameObject.name == "Player" && pc) {
			if (!Input.GetKey ("left") && !Input.GetKey ("right")) {
				target.gameObject.transform.position = new Vector3 (GetPositionX () + fdeltaX, target.gameObject.transform.position.y, target.gameObject.transform.position.z);
			}
		}
	}
}
