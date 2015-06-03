using UnityEngine;
using System.Collections;

public class SinPlatform : MonoBehaviour {

	//private float posX;
	//private float posY;
	// Use this for initialization
	public Key key;
	public bool OnKey = false;
	private bool flag = true;
	private bool flag2 = false;
	//public float sX = 0f;
	void Start () {
		if (!OnKey) {
			rigidbody2D.velocity = new Vector2 (-8f, 0f);
			//posX = transform.position.x;
			//posY = transform.position.y;
			if (rigidbody2D.velocity.x > 0f) {
				rigidbody2D.velocity = new Vector2 (8f, 0f);
			}
			if (rigidbody2D.velocity.x < 0f) {
				rigidbody2D.velocity = new Vector2 (-8f, 0f);
			}
		}
	}
	
	// Update is called once per frame
	void Update () {
		if (!flag2 && key.GetDown ()) {
			flag2 = true;
		}
		if (!key.GetDown ()) {
			rigidbody2D.velocity = new Vector2 (0f, -5f);
			flag = true;
			flag2 = false;
		}

		if (key && OnKey) {
			if (flag && flag2) {
				rigidbody2D.velocity = new Vector2 (-8f, 0f);
				if (rigidbody2D.velocity.x > 0f) {
					rigidbody2D.velocity = new Vector2 (8f, 0f);
				}
				if (rigidbody2D.velocity.x < 0f) {
					rigidbody2D.velocity = new Vector2 (-8f, 0f);
				}
				flag = false;
			}
		}

		if (key && OnKey) {
			if (!flag & flag2) {
				//print("update");
				//sX = rigidbody2D.velocity.x;

				if (rigidbody2D.velocity.x >= 0.1f) {
					//print("1");
					rigidbody2D.velocity = new Vector2 (8f, 0f);
				}
				if (rigidbody2D.velocity.x <= -0.1f) {
					//print("2");
					rigidbody2D.velocity = new Vector2 (-8f, 0f);
				}
				if (rigidbody2D.velocity.x <= 0.1f && rigidbody2D.velocity.x >= 0f) {
					//print("3");
					rigidbody2D.velocity = new Vector2 (-0.11f, 0f);
				}
				if (rigidbody2D.velocity.x >= -0.1f && rigidbody2D.velocity.x <= 0f) {
					//print("4");
					rigidbody2D.velocity = new Vector2 (+0.11f, 0f);
				}
			}
		}

		if (!OnKey) {
			if (rigidbody2D.velocity.x >= 0.1f) {
				rigidbody2D.velocity = new Vector2 (8f, 0f);
			}
			if (rigidbody2D.velocity.x <= -0.1f) {
				rigidbody2D.velocity = new Vector2 (-8f, 0f);
			}
			if (rigidbody2D.velocity.x <= 0.1f && rigidbody2D.velocity.x >= 0f) {
				rigidbody2D.velocity = new Vector2 (-0.11f, 0f);
			}
			if (rigidbody2D.velocity.x >= -0.1f && rigidbody2D.velocity.x <= 0f) {
				rigidbody2D.velocity = new Vector2 (+0.11f, 0f);
			}
		}

	}




}