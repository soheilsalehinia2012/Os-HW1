using UnityEngine;
using System.Collections;

public class FlubberController : MonoBehaviour {
	
	public Vector2 moving = new Vector2();
	public bool hor = true;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		moving.x = moving.y = 0;
		
		if (hor) {
			if (Input.GetKey ("right")) {
				moving.x = 1;
			} else if (Input.GetKey ("left")) {
				moving.x = -1;
			}
		}
		
		if (Input.GetButtonUp ("Horizontal")) {
			moving.x = 0;
		}
		
		if (Input.GetButtonDown ("Jump")) {
			moving.y = 1;
		}

		if (Input.GetButtonUp ("Jump")) {
			moving.y = 0;
		}
		
		//if (Input.GetKey ("down")) {
			//moving.y = -1;
		//}
		
	}
}
