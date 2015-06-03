using UnityEngine;
using System.Collections;

public class IronFalling : MonoBehaviour {

	public Key key;
	private Rigidbody2D rb2d;
	// Use this for initialization
	void Start () {
		rb2d = GetComponent<Rigidbody2D> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (key.GetDown ()) {
			rb2d.isKinematic = false;
		}
	}
}
