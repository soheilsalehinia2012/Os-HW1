using UnityEngine;
using System.Collections;

public class FallingPlatform : MonoBehaviour {

	public Key key;
	private bool first = true;
	private bool Grounded = false;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (key && key.GetDown () && first) {
			rigidbody2D.isKinematic = false;
			first = false;
		}
	}

	void OnCollisionEnter2D(Collision2D target){
		if (target.gameObject.name == "Player" && !Grounded) {
			Destroy(target.gameObject);

			GameObject go = new GameObject ("SpaceToContinue");
			SpaceToContinue script = go.AddComponent<SpaceToContinue> ();
			script.scene = Application.loadedLevelName;
			go.AddComponent<DisplayRestartText> ();
		}
		if (target.gameObject.tag == "RootFloor") {
			Grounded = true;
		}
	}
}
