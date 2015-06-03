using UnityEngine;
using System.Collections;

public class MovingPlatform : MonoBehaviour {


	public Key key;
	public float speed = -1f;
	public Transform sightStart, sightEndLeft, sightEndRight;
	public bool OnKey = false;
	private bool flag = true;//for each time we push key 
	private bool flag2 = false;//true when key down
	private bool direction = false;//if true meens it goes right 
	private bool collisionLeft = false;
	private bool collisionRight = false;
	// Use this for initialization
	void Start () {
		if (!OnKey) {
			rigidbody2D.velocity = new Vector2 (speed, 0f);
		}
	}
	
	// Update is called once per frame
	void Update () {
		if (!flag2 && key.GetDown ()) {
			flag2 = true;
		}
		if (!key.GetDown ()) {
			rigidbody2D.velocity = new Vector2 (0f, 0f);
			flag = true;
			flag2 = false;
		}
		if (key && OnKey) {
			if (flag && flag2 ) {
				if(direction){
					rigidbody2D.velocity = new Vector2 (-speed, 0f);
				}else{
					rigidbody2D.velocity = new Vector2 (speed, 0f);
				}
				flag = false;
			}

		}

		if (key && OnKey) {
			if (!flag & flag2) {
		
				collisionLeft = Physics2D.Linecast (sightStart.position, sightEndLeft.position, 1 << LayerMask.NameToLayer ("Solid"));
				collisionRight = Physics2D.Linecast (sightStart.position, sightEndRight.position, 1 << LayerMask.NameToLayer ("Solid"));
		
				Debug.DrawLine (sightStart.position, sightEndLeft.position, Color.green);
				Debug.DrawLine (sightStart.position, sightEndRight.position, Color.green);
		
		
				if (collisionLeft) {
					rigidbody2D.velocity = new Vector2 (0f, 0f);
					StartCoroutine (Backward ());
				}
		
				if (collisionRight) {
					rigidbody2D.velocity = new Vector2 (0f, 0f);
					StartCoroutine (Forward ());
				}
			}
		}


			if (!OnKey) {
				collisionLeft = Physics2D.Linecast (sightStart.position, sightEndLeft.position, 1 << LayerMask.NameToLayer ("Solid"));
				collisionRight = Physics2D.Linecast (sightStart.position, sightEndRight.position, 1 << LayerMask.NameToLayer ("Solid"));
			
				Debug.DrawLine (sightStart.position, sightEndLeft.position, Color.green);
				Debug.DrawLine (sightStart.position, sightEndRight.position, Color.green);
			
			
				if (collisionLeft) {
					rigidbody2D.velocity = new Vector2 (0f, 0f);
					StartCoroutine (Backward ());
				
				}
			
				if (collisionRight) {
					rigidbody2D.velocity = new Vector2 (0f, 0f);
					StartCoroutine (Forward ());
				}
			}

	}
	IEnumerator Backward(){
		yield return new WaitForSeconds (1f);
		rigidbody2D.velocity = new Vector2 (-speed, 0f);
		direction = true;
		//collisionLeft = false;
	}

	IEnumerator Forward(){
		yield return new WaitForSeconds (1f);
		rigidbody2D.velocity = new Vector2 (speed, 0f);
		direction = false;
		//collisionRight = false;
	}
	

}
