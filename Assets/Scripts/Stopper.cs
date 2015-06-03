using UnityEngine;
using System.Collections;

public class Stopper : MonoBehaviour {

	private BoxCollider2D ec2d;
	public bool flag = false ;
	// Use this for initialization
	void Start () {
		ec2d = GetComponent<BoxCollider2D> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (flag) {
			ec2d.isTrigger = false;
			print ("aa");
			flag = false;
		}
	}

	void OnCollisionEnter2D(Collision2D target){
	
		if (target.gameObject.tag == "Player" && !flag) {
			ec2d.isTrigger = true;
			flag = 	true;
			print ("bb");
		}
	}

	/*void OnCollisionExit2D(Collision2D target){
		print ("aa");
		if (target.gameObject.tag == "Player" && flag) {
			ec2d.isTrigger = false;
			print ("aa");
			flag = false;
		}
	}*/
}
